using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBloated : Enemy
{

    [SerializeField] private float movespeed = 2f;
    [SerializeField] private float timeToChangeDirection = 2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool movingRight = false;
    private int moveDirection = 1; // -1 for left, 1 for right
    [SerializeField] private float timer = 0f;
    //[SerializeField] private LanzaPiedras lp;
    [SerializeField] private LanzaOndas lo;
    [SerializeField] private SpriteRenderer SR;

    [SerializeField] private GameObject proyectil;
    [SerializeField] private float proyectilspeed;


    public bool activarBoss;
    private bool atacando = false;
    private Rigidbody2D RB;
    minibossStates ms = minibossStates.Inactivo;
    public Transform _punchCheck;


    public BigBloated()
    {
        
        
    }

    public enum minibossStates
    {
        Persiguiendo,
        Atacando,
        Inactivo

    }

    private void Start()
    {
        moveDirection = movingRight ? 1 : -1;
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
       
    }


    public override void Attack()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();
        

    }

    public override void Move()
    {
        anim.SetBool("move", true);

        transform.Translate(moveDirection * Vector2.right * speed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= timeToChangeDirection)
        {
            moveDirection *= -1;
            UpdateSpriteOrientation();

            timer = 0f;
        }
    }
    public void UpdateSpriteOrientation()
    {
        // Flip the sprite along the X-axis if moving left
        if (moveDirection < 0)
        {
            SR.flipX = false;
        }
        else
        {
            SR.flipX = true;
        }
    }

    protected override void Update()
    {
        Move();
        switch (ms)
        {
            case minibossStates.Persiguiendo:
              //  activado = true;
                if (atacando == false)
                {
                    atacando = true;
                    StartCoroutine(Ataque());
                }
                break;
        }
    }

   

    public override void TakeDmg()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activarBoss == false && collision.gameObject.tag == "Player")
        {
            activarBoss = true;
           // activado = true;
            ms = minibossStates.Persiguiendo;

        }

    }

    IEnumerator Ataque()
    {

        ms = minibossStates.Atacando;
        yield return new WaitForSeconds(2.5f);
        
        if ( lo.dentroDeAreaOndas)
        {
           // activado = false;
            LanzarOndas();
            anim.SetBool("Lanzar", true);

        }
        yield return new WaitForSeconds(1f);
        ms = minibossStates.Persiguiendo;
        atacando = false;
        anim.SetBool("Lanzar", false);
        anim.SetBool("LanzarPiedra", false);

    }

    private void LanzarOndas()
    {
        InstanciateProjectile(proyectil, proyectilspeed);

    }

    private void InstanciateProjectile(GameObject projectile, float speed)
    {
        if (facingRight)
        {

            GameObject flechaClone;
            flechaClone = Instantiate(proyectil, _punchCheck.transform.position, Quaternion.identity);
            flechaClone.GetComponent<Rigidbody2D>().velocity = new Vector2(1 * proyectilspeed, rg2D.velocity.y);
            flechaClone.transform.localScale = new Vector3(1, 1, 1);


        }
        else //(attackingRight)
        {
            GameObject flechaClone;
            flechaClone = Instantiate(proyectil, _punchCheck.transform.position, Quaternion.identity);
            flechaClone.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * proyectilspeed, rg2D.velocity.y);
            flechaClone.transform.localScale = new Vector3(-1, 1, 1);

        }
    }
}
