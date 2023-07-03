using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPatrol : MonoBehaviour
{
    
    
    [Header("Patrol Points")]
    // Puntos de referencia para que el enemigo sepa cuando ir en la otra direcion
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    //El enemigo como tal
    [SerializeField] private Transform enemy ;


    [Header("Movement Parameter")]
    // Velocidad 
    [SerializeField] private float speed;
    private Vector3 initScale;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;


    private bool movingLeft;
   
    
    

    private void Awake()
    {
        initScale = enemy.localScale;
        leftEdge.parent = null;
        rightEdge.parent = null;
       
    }

     private void Start()
    {
       
       
    }
    private void Update()
    {
        //Condiciones para que el enemigo se de la vuelta
        if(movingLeft)
        {
            //Si la posicion del enemigo es mayor o igual al punto de refrencia left Edge tons se mueve si no cambia
            if(enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirecctionChange();
            }
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirecctionChange();
            }
        }

    }

    private void DirecctionChange()
    {
        anim.SetBool("Moving", true);

        //! operator invierte el valor en este caso de true a false
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {

        anim.SetBool("Moving", true);
        //Make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        //Move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }

    



}
