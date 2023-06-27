using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Variables
    public float tiempoTranscurrido = 0f;
    [SerializeField] private Rigidbody2D _rig;
    [SerializeField] private float _runSpeed = 40f;
    [SerializeField] private bool _grounded;
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
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        _rig.velocity = new Vector2(horizontalMove * _runSpeed, _rig.velocity.y);
        _animator.SetFloat("runSpeed", Mathf.Abs(horizontalMove));

        if (horizontalMove < 0 && _facingRight == true)
        {
            Flip();
        }
        if (horizontalMove > 0 && _facingRight == false)
        {
            Flip();
        }
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, _groundRadius, _LayerGround);
        _animator.SetBool("grounded", _grounded);
        if (Input.GetButtonUp("Jump") && _grounded == true)
        {

            if (_timer < 3f)
            {
                Jump();
                StartCoroutine(RegresaralSuelo());
            }
            else
            {
               
                    JumpSpecial();
       

            }
            _timer = 0;
        }





        if (Input.GetButton("Jump") && _grounded == true)
        {

            _timer = _timer + Time.deltaTime;
        }

        //Debug.Log(_timer);


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
    IEnumerator RegresaralSuelo()
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
    void Jump()
    {
       
        _animator.SetBool("Jump", true);
        _rig.velocity = Vector2.up * _jumpForce;
    }

    void JumpSpecial()
    {
        Debug.Log("Salto especial");
        Jump();
        isStomping = true;
        StartCoroutine(StumpJump());
    }

    IEnumerator StumpJump()
    {
        yield return new WaitForSeconds(_stumpTimer);
        _rig.velocity = Vector2.down * _jumpForce * 2;
        yield return new WaitForSeconds(1f);
        isStomping = false;
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