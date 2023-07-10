using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBloated : Enemy
{

    private float movespeed = 2f;
    
    private bool movingLeft, movingRight;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;
    
    private Rigidbody2D RB;
    [SerializeField] private SpriteRenderer SR;

    public BigBloated()
    {
        
        
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        GameObject _leftEdge = GameObject.Find("BLeftEdge");
        GameObject _rightEdge = GameObject.Find("BRightEdge");
        
        
        

        if (_leftEdge != null)
        {
            leftEdge = _leftEdge.transform;
        }
        if (_rightEdge != null)
        {
            rightEdge = _rightEdge.transform;
        }
    }


    public override void Attack()
    {
        
    }

    protected override void Awake()
    {
        base.Awake();

    }

    public override void Move(int speed)
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
}
