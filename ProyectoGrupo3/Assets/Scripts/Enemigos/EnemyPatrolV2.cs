using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

public class EnemyPatrolV2 : MonoBehaviour
{

    public GameObject leftEdge, rightEdge;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    private float moveSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = rightEdge.transform;
        anim.SetBool("move", true);
        

    }

    // Update is called once per frame
    void Update()
    {
        // Give us the direciotn the enemy will move whihc is the psotion of the current point.
        Vector2 point = currentPoint.position - transform.position;

        if(currentPoint == rightEdge.transform)
        {
            rb.velocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0);
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == rightEdge.transform)
        {
            currentPoint = leftEdge.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == leftEdge.transform)
        {
            currentPoint = rightEdge.transform;
        }
    }
}
