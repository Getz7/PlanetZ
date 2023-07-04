using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centipede : Enemy
{

    private float movespeed = 2f;
    private Animator anim;
    private bool movingLeft;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;


    public Centipede()
    {
        

    }

    public override void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        GameObject _leftEdge = GameObject.Find("LeftEdge");
        GameObject _rightEdge = GameObject.Find("RightEdge");

        if(_leftEdge != null)
        {
            leftEdge = _leftEdge.transform;
        }
        if (_rightEdge != null)
        {
            rightEdge = _rightEdge.transform;
        }


    }



    public  virtual void TakeDamage(float _damage)
    {
        
    }


    private void Update()
    {
        //Condiciones para que el enemigo se de la vuelta
        if (movingLeft)
        {
            //Si la posicion del enemigo es mayor o igual al punto de refrencia left Edge tons se mueve si no cambia
            if (transform.position.x >= leftEdge.position.x)
                Move(-1);
            else
            {
                DirecctionChange();
            }
        }
        else
        {
            if (transform.position.x <= rightEdge.position.x)
                Move(1);
            else
            {
                DirecctionChange();
            }
        }
    }
    public override void Attack()
    {

    }

    public override void Move(int _direction)
    {
        anim.SetBool("move", true);
        
        transform.localScale = new Vector3(transform.localScale.x * _direction, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * movespeed, transform.position.y, transform.position.z);
    }
    public override void DirecctionChange()
    {
        anim.SetBool("move", false);

        //! operator invierte el valor en este caso de true a false
        movingLeft = !movingLeft;
    }

}
