using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : Enemy
{

    

    private int moveDirection = 1; // -1 for left, 1 for right
    private float timer = 0f;
    private Rigidbody2D RB;
    private SpriteRenderer SR;
    private BoxCollider2D box;


    public Centipede()
    {
        

    }

    protected override void Awake()
    {
        base.Awake();

    }

    protected override void Start()
    {
        // Adjust the initial movement direction based on 'startMovingRight' variable
        moveDirection = movingRight ? 1 : -1;
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
      

    }






    protected override void  Update()
    {
        Move();
    }
    public override void Attack()
    {

    }
    private  void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player != null)
            {

                player.Hurt((int)GetDamage());
            }
        }

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

    public override void TakeDmg(float dmgAmount)
    {
        Health -= dmgAmount;
        anim.SetTrigger("hurt");
        if(Health <= 0)
        {
            FindObjectOfType<GameManager>().EnemigoDestruido();
            Invoke("Die", 0.1f);
        }
    }

    public override void Die()
    {
        anim.SetTrigger("die");
        // this.gameObject.SetActive(false);
        GetComponent<Enemy>().enabled = false;
    }

    public float GetDamage()
    {
        return Damage;
    }
}
