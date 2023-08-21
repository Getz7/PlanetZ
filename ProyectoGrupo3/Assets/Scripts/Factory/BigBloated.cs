using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBloated : Enemy
{
    private int moveDirection = 1; // -1 for left, 1 for right
    private float timer = 0f;
    
    
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float throwForce;
    private float detectionRange = 5f;
    [SerializeField] private float projectileCooldown;

    [SerializeField] private GameObject key;
    
    private bool hasDroppedKey = false;



    public bool activarBoss;
    private bool atacando = false;
    private Rigidbody2D RB;
    public Transform playerPos; // Reference to the player's transform
    private bool playerInSight = false;
    private float lastProjectileTime = 0f;
    private BoxCollider2D box;




    public BigBloated()
    {
        
        
    }



    protected override void Start()
    {
        moveDirection = movingRight ? 1 : -1;
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        box = GetComponent<BoxCollider2D>();

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

        transform.Translate(moveDirection * Vector2.right * MoveSpeed * Time.deltaTime);

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
        // Check if player is in sight
        playerInSight = Vector2.Distance(transform.position, playerPos.position) <= detectionRange;
        if (playerInSight)
        {
            
            if(Time.time - lastProjectileTime >= projectileCooldown)
            {
                // Throw projectile at the player
                ThrowProjectile();
                lastProjectileTime = Time.time;
            }
            
        }

    }


    //Take dmage from player
    public override void TakeDmg(float dmgAmount)
    {
        Health -= dmgAmount;
        anim.SetTrigger("hurt");
        if (Health <= 0)
        {
            FindObjectOfType<GameManager>().EnemigoDestruido();
            Invoke("Die", 0.1f);
        }
    }


    //Deal damage to PLayer
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player != null)
            {

                player.Hurt((int)GetDamage());
            }
        }

    }

    private void ThrowProjectile()
    {
        anim.SetBool("move", false); // Stop moving when attacking
        anim.SetTrigger("attack");   // Trigger attack animation

        // Calculate direction to player
        Vector2 direction = (playerPos.position - throwPoint.position).normalized;

        // Instantiate and throw projectile
        GameObject projectile = Instantiate(projectilePrefab, throwPoint.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = direction * throwForce;

        // Update sprite orientation based on projectile direction
        if (direction.x < 0)
        {
            SR.flipX = false;
        }
        else
        {
            SR.flipX = true;
        }
    }

    public override void Die()
    {

        anim.SetTrigger("die");
        //this.gameObject.SetActive(false);
        GetComponent<BigBloated>().enabled = false;
        box.enabled = false;

        hasDroppedKey = true;
            FindObjectOfType<GameManager>().EnemigoDestruido();
            if (key != null) Instantiate(key, this.transform.position, Quaternion.identity);
        
    }

    public float GetDamage()
    {
        return Damage;
    }
}
