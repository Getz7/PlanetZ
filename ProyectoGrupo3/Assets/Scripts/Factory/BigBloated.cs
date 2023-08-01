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



    private Rigidbody2D RB;
    [SerializeField] private SpriteRenderer SR;

    public BigBloated()
    {
        
        
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
    }

   

    public override void TakeDmg()
    {
        
    }
}
