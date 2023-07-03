using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour  
{
    public float moveSpeed;

    public Transform leftPoint, rigthPoint;

    private bool movingRight;

    private Rigidbody2D theRB;
    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
