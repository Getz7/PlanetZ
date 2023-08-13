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
    
    
    [SerializeField] private SpriteRenderer SR;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float throwForce;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float projectileCooldown;



    public bool activarBoss;
    private bool atacando = false;
    private Rigidbody2D RB;
    public Transform playerPos; // Reference to the player's transform
    private bool playerInSight = false;
    private float lastProjectileTime = 0f;




    public BigBloated()
    {
        
        
    }

    

    private void Start()
    {
        moveDirection = movingRight ? 1 : -1;
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

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



    public override void TakeDmg()
    {
        
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






}
