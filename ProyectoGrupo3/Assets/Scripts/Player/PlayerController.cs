using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
//using UnityEditor.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField] public int _HealthPoints = 6;
    [SerializeField] private float _stumpTimer;
    [SerializeField] private bool _canSpecial = false;
    [SerializeField] private GameObject _olaPrefab;
    private ControladorPuntos controladorPuntos;
    public DeathBySpikes deathBySpikes;
    private DecoratorData decoratorData;
    [SerializeField] private bool _shieldActive = false;
    [SerializeField] private float _shieldDuration = 2.0f;
    [SerializeField] private float _shieldCooldown = 5.0f;
    [SerializeField] private float _shieldCooldownTimer = 0.0f;
    [SerializeField] private float _shieldVulnerabilityDuration = 1.0f;
    [SerializeField] private GameObject _activeShieldUI;
    [SerializeField] private GameObject _unavailableShieldUI;
    [SerializeField] private GameObject oxigeno1;
    [SerializeField] private GameObject oxigeno2;
    [SerializeField] private GameObject oxigeno3;
    [SerializeField] private GameObject oxigeno4;
    [SerializeField] private GameObject oxigeno5;
    [SerializeField] private GameObject oxigeno6;
    [SerializeField] private GameObject oxigeno7;
    [SerializeField] private GameObject oxigeno8;
    [SerializeField] private GameObject oxigeno9;
    [SerializeField] private GameObject oxigeno10;
    [SerializeField] private GameObject oxigeno11;
    [SerializeField] public int puntosOxigeno = 45;
    
    [SerializeField] private float tiempoPuntosOxigeno;
    private float tiempoHabilidad;
    private bool recuperarVelocidad = false;
    private float tiempoRecuperacion = 15f;
    private float tiempoUso = 15;
    private bool velocidadReducida = false;
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
        decoratorData = DecoratorData.Instance;
        controladorPuntos = ControladorPuntos.Instancia;
        _jumpCommand = new JumpCommand(this);
        _jumpSpecialCommand = new SpecialJumpCommand(this);

      
        PlayerInputHandler inputHandler = FindObjectOfType<PlayerInputHandler>();
        if (inputHandler != null)
        {
            inputHandler.SetJumpCommand(_jumpCommand);
            inputHandler.SetSpecialJumpCommand(_jumpSpecialCommand);
        }
    }
    private void LoadPuntosOxigenoFromPlayerDataManager()
    {
        puntosOxigeno = PlayerDataManager.Instance.puntosOxigeno;
    }

    public bool HasEnoughPoints(int amount)
    {
        return controladorPuntos.CantidadPuntos >= amount;
    }

    public void DeductPoints(int amount)
    {
        controladorPuntos.CantidadPuntos -= amount;
    }
    public bool IsShieldActive()
    {

        return _shieldActive;
    }


    void Start()
    {

        LoadPuntosOxigenoFromPlayerDataManager();
        escenaActual = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("escenaActual", escenaActual);
        _canBehurt = true;
        _animator = GetComponent<Animator>();

        originalGravity = _rig.gravityScale;
        _activeShieldUI.SetActive(false);
        _unavailableShieldUI.SetActive(true);
        oxigeno1.SetActive(false);  
        oxigeno2.SetActive(false);  
        oxigeno3.SetActive(false);  
        oxigeno4.SetActive(false);
        oxigeno5.SetActive(false);
        oxigeno6.SetActive(false);
        oxigeno7.SetActive(false);
        oxigeno8.SetActive(false);
        oxigeno9.SetActive(false);
        oxigeno10.SetActive(false);
        oxigeno11.SetActive(false);


    }
    public int GetPoints()
    {
        return puntosOxigeno;
    }
  




    void Update()
    {
        
        ControladorTiempoSalto();
        ControladorMovimiento();
        ControladorAtaques();
        if (Input.GetKeyDown(KeyCode.Q) && _shieldCooldownTimer <= 0)
        {
            ActivateShield();
        }


        controlTanque();
        showtanques();

    }
    


    private bool habilidadActivada = false;
    private float tiempoHabilidadActivada;

    private void showtanques()
    {
     switch(puntosOxigeno)
        {
            case 15:
                oxigeno1.SetActive(true);
                break;
            case 30:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                break;
            case 45:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true); 
                oxigeno3.SetActive(true);
                break;
            case 60:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                oxigeno3.SetActive(true);
                oxigeno4.SetActive(true);  
                break;
            case 75:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                oxigeno3.SetActive(true);
                oxigeno4.SetActive(true);
                oxigeno5.SetActive(true);   
                break;
            case 90:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                oxigeno3.SetActive(true);
                oxigeno4.SetActive(true);
                oxigeno5.SetActive(true);
                oxigeno6.SetActive(true);   
                break;
            case 105:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                oxigeno3.SetActive(true);
                oxigeno4.SetActive(true);
                oxigeno5.SetActive(true);
                oxigeno6.SetActive(true);
                oxigeno7.SetActive(true);   
                break;
            case 120:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                oxigeno3.SetActive(true);
                oxigeno4.SetActive(true);
                oxigeno5.SetActive(true);
                oxigeno6.SetActive(true);
                oxigeno7.SetActive(true);
                oxigeno8.SetActive(true);
                break;
            case 135:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                oxigeno3.SetActive(true);
                oxigeno4.SetActive(true);
                oxigeno5.SetActive(true);
                oxigeno6.SetActive(true);
                oxigeno7.SetActive(true);
                oxigeno8.SetActive(true);
                oxigeno9.SetActive(true);   
                break;
            case 150:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                oxigeno3.SetActive(true);
                oxigeno4.SetActive(true);
                oxigeno5.SetActive(true);
                oxigeno6.SetActive(true);
                oxigeno7.SetActive(true);
                oxigeno8.SetActive(true);
                oxigeno9.SetActive(true);
                oxigeno10.SetActive(true);
                break;
            case 165:
                oxigeno1.SetActive(true);
                oxigeno2.SetActive(true);
                oxigeno3.SetActive(true);
                oxigeno4.SetActive(true);
                oxigeno5.SetActive(true);
                oxigeno6.SetActive(true);
                oxigeno7.SetActive(true);
                oxigeno8.SetActive(true);
                oxigeno9.SetActive(true);
                oxigeno10.SetActive(true);
                oxigeno11.SetActive(true);  
                break;
        }
    }


    private List<IDecorator> _decorators = new List<IDecorator>();
    public void ApplyDecorators(IDecorator decorator)
    {
        _decorators.Add(decorator);
        decorator.ApplyDecorator(this);
    }
    public void ApplyPoints(int pointsToAdd)
    {
        puntosOxigeno += pointsToAdd;
    }



    private void controlTanque()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_HealthPoints < 6 && puntosOxigeno > 0)
            {
                puntosOxigeno = puntosOxigeno - 15;
                habilidadActivada = true;
                tiempoHabilidadActivada = Time.time;
                switch (puntosOxigeno)
                {
                    case 150:
                        oxigeno11.SetActive(false);
                        velocidadReducida = true;
                        tiempoUso = 15f;
                        break;
                    case 135:
                        oxigeno10.SetActive(false);
                        velocidadReducida = true;
                        tiempoUso = 15f;
                        break;
                    case 120:
                        oxigeno9.SetActive(false);
                        velocidadReducida = true;
                        tiempoUso = 15f;
                        break;
                    case 105:
                        oxigeno8.SetActive(false);
                        velocidadReducida = true;
                        tiempoUso = 15f;
                        break;
                    case 90:
                        oxigeno7.SetActive(false);
                        velocidadReducida = true;
                        tiempoUso = 15f;
                        break;
                    case 75:
                        oxigeno6.SetActive(false);
                        velocidadReducida = true;
                        tiempoUso = 15f;
                        break;
                    case 60:
                        oxigeno5.SetActive(false);
                        _runSpeed = 4;
                        _HealthPoints = _HealthPoints + 1;
                        velocidadReducida = true;
                        tiempoUso = 15f;
                        _runSpeed = 4;
                        _HealthPoints = _HealthPoints + 1;
                        break;
                    case 45:
                        oxigeno4.SetActive(false);
                        _runSpeed = 4;
                        _HealthPoints = _HealthPoints + 1;
                        velocidadReducida = true;
                        tiempoUso = 15f;

                        break;
                    case 30:
                        oxigeno3.SetActive(false);
                        _runSpeed = 4;
                        _HealthPoints = _HealthPoints + 1;
                        velocidadReducida = true;
                        tiempoUso = 15f;

                        break;
                    case 15:
                        oxigeno2.SetActive(false);
                        _runSpeed = 4;
                        _HealthPoints = _HealthPoints + 1;
                        velocidadReducida = true;
                        tiempoUso = 15f;

                        break;
                    case 0:
                        oxigeno1.SetActive(false);
                        _runSpeed = 4;
                        _HealthPoints = _HealthPoints + 1;
                        velocidadReducida = true;
                        tiempoUso = 15f;
                        break; // Termina o switch case

                }

            } Debug.Log("Tienes la vida full");
        }
       

        if (habilidadActivada && Time.time - tiempoHabilidadActivada >= 15f)
        {
            habilidadActivada = false; // Restablecemos la habilidad a su estado original
            _runSpeed = 8; // Volvemos a la velocidad original de 8
        }


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



    private List<Decorator> decorators = new List<Decorator>();

    public void ApplyDecorator(Decorator decorator)
    {
        decorators.Add(decorator);
        decorator.ApplyDecorator(this);
    }

    public void ApplyHealthDecorator(int healthBoostAmount)
    {
        _HealthPoints += healthBoostAmount;

    }

    public void ApplySpeedDecorator(float speedBoostAmount, float duration)
    {
        IncreaseRunSpeedTemporarily(speedBoostAmount, duration);
    }


    public void ApplyDecoratorToPlayerData(Decorator decorator)
    {
        DecoratorData.Instance.AddItemToInventory(decorator.getItem());
    }

    private bool isPlaying = false; // Variable para controlar si el sonido est� reproduci�ndose o no

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
        if (Input.GetKeyDown(KeyCode.Q) && _shieldCooldownTimer <= 0)
        {
            ActivateShield();
        }
    }

    public void DecreaseHealth(int amount)
    {
        _HealthPoints -= amount;

    }
    public void IncreaseJumpForceTemporarily(float extraForce, float duration)
    {
        _jumpForce += extraForce;
        StartCoroutine(RestoreJumpForceAfterDuration(extraForce, duration));
    }

    private IEnumerator RestoreJumpForceAfterDuration(float extraForce, float duration)
    {
        yield return new WaitForSeconds(duration);
        _jumpForce -= extraForce;
    }

    public void IncreaseRunSpeedTemporarily(float extraSpeed, float duration)
    {
        _runSpeed += extraSpeed;
        StartCoroutine(RestoreRunSpeedAfterDuration(extraSpeed, duration));
    }

    private IEnumerator RestoreRunSpeedAfterDuration(float extraSpeed, float duration)
    {
        yield return new WaitForSeconds(duration);
        _runSpeed -= extraSpeed;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        Item item = other.GetComponent<Item>();

        if (item != null)
        {
            ItemVisitor itemVisitor = new ItemVisitor();
            item.Accept(itemVisitor);

            other.gameObject.SetActive(false);
        }
    }
    private void ActivateShield()
    {
        _shieldActive = true;
        _shieldCooldownTimer = _shieldCooldown;

        _activeShieldUI.SetActive(true);
        _unavailableShieldUI.SetActive(false);

        StartCoroutine(ShieldCooldownTimer());
        StartCoroutine(ShieldVulnerabilityTimer());
    }

    private IEnumerator ShieldVulnerabilityTimer()
    {
        yield return new WaitForSeconds(_shieldDuration);

        _shieldActive = false;

        _activeShieldUI.SetActive(false);
        _unavailableShieldUI.SetActive(true);

        StartCoroutine(ShieldCooldownTimer());
    }

    public IEnumerator ShieldVulnerabilityPeriod()
    {
        yield return new WaitForSeconds(_shieldDuration);
        _shieldActive = false;

    }


    private IEnumerator ShieldCooldownTimer()
    {
        while (_shieldCooldownTimer > 0)
        {
            yield return new WaitForSeconds(1.0f);
            _shieldCooldownTimer -= 1.0f;
        }


        _shieldActive = false;


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
            InstanciateProjectile(_olaPrefab, 10f);
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
        if (_facingRight)
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
            if (!_shieldActive)
            {
                _canBehurt = false;
                _HealthPoints -= damage;
                StartCoroutine(Invulnerability());

                if (_HealthPoints <= 0)
                {
                    this.gameObject.SetActive(false);
                    SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                }
                else
                {
                    StartCoroutine(ShieldVulnerabilityPeriod());
                }
            }
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