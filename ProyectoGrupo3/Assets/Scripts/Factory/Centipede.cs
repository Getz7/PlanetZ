using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : Enemy
{

    [SerializeField] private float movespeed = 3f;
    private bool movingLeft, movingRight;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    private Rigidbody2D RB;
    [SerializeField] private SpriteRenderer SR;


    public Centipede()
    {
        

    }

    protected override void Awake()
    {
        base.Awake();

    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        GameObject _rightEdge = GameObject.Find("RightEdge");
        GameObject _leftEdge = GameObject.Find("LeftEdge");

        if(_leftEdge != null)
        {
            leftEdge = _leftEdge.transform;
        }
        if(_rightEdge != null)
        {
            rightEdge = _rightEdge.transform;
        }


    }



    public  virtual void TakeDamage(float _damage)
    {
        
    }


    private void Update()
    {
        if (movingRight)
        {
           RB.velocity = new Vector2(movespeed, RB.velocity.y);

            SR.flipX = true;
            if (transform.position.x > rightEdge.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            RB.velocity = new Vector2(-movespeed, RB.velocity.y);
            SR.flipX = false;
            if (transform.position.x < leftEdge.position.x)
            {
                movingRight = true;
            }
        }
        anim.SetBool("move", true);
    }
    public override void Attack()
    {

    }

    public override void Move(int speed) 
    {
       
        
        
    }
    

}
