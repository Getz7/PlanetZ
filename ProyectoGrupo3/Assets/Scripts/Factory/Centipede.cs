using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : Enemy
{

    [SerializeField] private float movespeed = 3f;
    [SerializeField] private float timeToChangeDirection = 2f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private bool movingRight = false;
    private int moveDirection = 1; // -1 for left, 1 for right
    [SerializeField] private float timer = 0f;
    private Rigidbody2D RB;
     private SpriteRenderer SR;


    public Centipede()
    {
        

    }

    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        // Adjust the initial movement direction based on 'startMovingRight' variable
        moveDirection = movingRight ? 1 : -1;
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
      

    }



    


    private void Update()
    {
        Move();
    }
    public override void Attack()
    {

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

    public override void TakeDmg()
    {
        
    }
}
