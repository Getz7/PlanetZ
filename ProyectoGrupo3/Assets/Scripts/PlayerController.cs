using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;
using UnityEngine.SceneManagement;

//receiver


public class PlayerController : MonoBehaviour
{
    private ICommand _jumpCommand;
    private ICommand _jumpSpecialCommand;
    //Variables
    public int sceneBuildIndex;
    [SerializeField] public float tiempoTranscurrido = 0f;
    [SerializeField] public float jumpCooldown = 0.5f;
    [SerializeField] private float jumpTimer = 0f;
    [SerializeField] private Rigidbody2D _rig;
    [SerializeField] private float _runSpeed = 40f;
    [SerializeField] private bool _grounded = true;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundRadius = 0.5f;
    [SerializeField] private float _punchRadius = 0.5f;
    [SerializeField] private LayerMask _LayerGround;
    [SerializeField] private LayerMask _LayerInteract;
    [SerializeField] private float _jumpForce = 40f;
    [SerializeField] private Transform _punchCheck;
    [SerializeField] private bool _facingRight = true;
    [SerializeField] private GameObject _hitbox;
    [SerializeField] public int _HealthPoints = 5;
    [SerializeField] private float _stumpTimer;
    [SerializeField] private bool _canSpecial = false;
    private Animator _animator;   
    private float _timer;
    private bool _canBehurt = true;
    private int _playerDamage = 1;
    private float originalGravity;
    public string escenaActual;
    public bool isStomping = false;
    AudioClip playerAudio;
    private void Awake()
    {
        _jumpCommand = new JumpCommand(this);
        _jumpSpecialCommand = new SpecialJumpCommand(this);

        // Get reference to the PlayerInputHandler and set the commands
        PlayerInputHandler inputHandler = FindObjectOfType<PlayerInputHandler>();
        if (inputHandler != null)
        {
            inputHandler.SetJumpCommand(_jumpCommand);
            inputHandler.SetSpecialJumpCommand(_jumpSpecialCommand);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        escenaActual = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("escenaActual", escenaActual);
        _canBehurt = true;
        _animator = GetComponent<Animator>();
   
        originalGravity = _rig.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        ControladorTiempoSalto();
       ControladorMovimiento();
       ControladorAtaques();
     
    }
    private void ControladorTiempoSalto()
    {
        if (!_grounded)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0f)
            {
                _grounded = true;
                _animator.SetBool("Jump", false); // Set the "Jump" parameter to false when grounded
            }
        }
    }

   


    private bool isPlaying = false; // Variable para controlar si el sonido está reproduciéndose o no

    private void ControladorMovimiento()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        _rig.velocity = new Vector2(horizontalMove * _runSpeed, _rig.velocity.y);
        _animator.SetFloat("runSpeed", Mathf.Abs(horizontalMove));
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _LayerGround);
        _animator.SetBool("grounded", _grounded);

        if (horizontalMove < 0 && _facingRight == true)
        {
            
            Flip();
            
            if (!isPlaying)
            {
                ControladorSonidos.Instance.PlayerSound();
                isPlaying = true;
            }
        }
        else if (horizontalMove > 0 && _facingRight == false)
        {

            Flip();
            
            if (!isPlaying)
            {
                ControladorSonidos.Instance.PlayerSound();
                isPlaying = true;
            }
        }

        else if (horizontalMove == 0)
        {
            
            if (isPlaying)
            {
                ControladorSonidos.Instance.StopPlayerSound();
                isPlaying = false;
            }
        }

        _animator.SetBool("move", horizontalMove != 0);
    }

   

    private void ControladorAtaques()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Punch();
            Debug.Log("Impacte");
        }

        if (Input.GetMouseButtonDown(1) && _canSpecial)
        {
            _canSpecial = false;
            _animator.SetBool("SpecialAttack", false);
            
        }
    }

    
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_groundCheck.position, _groundRadius);
        Gizmos.DrawWireSphere(_punchCheck.position, _punchRadius);
        //Gizmos.DrawWireSphere(_aplausoCheck.position, _aplausoRadius);
    }
    private void InstanciateProjectile(GameObject projectile, float speed)
    {
        GameObject prefab = Instantiate(projectile, _punchCheck.position, Quaternion.identity);
        if (!_facingRight)
        {
            prefab.GetComponent<Rigidbody2D>().velocity = _punchCheck.right * speed;

        }
        else
        {
            prefab.transform.localScale = new Vector3(-prefab.transform.localScale.x, prefab.transform.localScale.y, prefab.transform.localScale.z);
            prefab.GetComponent<Rigidbody2D>().velocity = -_punchCheck.right * speed;
        }
    }
    void Flip()
    {
        Debug.Log("Se ejecuto el flip");
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _facingRight = !_facingRight;
    }
    public void Jump()
    {

        if (_grounded)
        {
            Debug.Log("Salto");
            _animator.SetBool("Jump", true);
            
            _rig.velocity = Vector2.up * _jumpForce;
            _grounded = false;
            jumpTimer = jumpCooldown;
            ControladorSonidos.Instance.PlayerJump();
        }
    }

    public void JumpSpecial()
    {
        Debug.Log("Salto especial");
        Jump();
        isStomping = true;
        StartCoroutine(StumpJump());
    }
     public IEnumerator RegresaralSuelo()
    {
        yield return new WaitForSeconds(0.1f);
        if (!_grounded)
        {
            _animator.SetBool("Jump", true);
        }
        else
        {
            _animator.SetBool("Jump", false);
        }
    }

    public IEnumerator StumpJump()
    {
        yield return new WaitForSeconds(_stumpTimer);
        _rig.velocity = Vector2.down * _jumpForce * 2;
        yield return new WaitForSeconds(1f);
        isStomping = false;
    }
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        
    }
    void Punch()
    {
        _animator.SetTrigger("Attack");
        if (Physics2D.OverlapCircle(_groundCheck.position, _punchRadius, _LayerInteract))
        {
            _hitbox.SetActive(true);
        }
        else
        {
            _hitbox.SetActive(false);
        }
    }
    public void Hurt(int damage)
    {
        if (_canBehurt)
        {
            _canBehurt = false;
            _HealthPoints -= damage;
            StartCoroutine(Invulnerability());
        }
        if (_HealthPoints <= 0)
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    
    
    IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(2f);
        _canBehurt = true;
    }
    public int GetDamage()
    {
        return _playerDamage;
    }
    public void ActiveSpecial(bool flag)
    {
        _canSpecial = true;
        _animator.SetBool("SpecialAttack", true);
    }

  
}