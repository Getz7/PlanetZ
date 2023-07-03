using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float startingHP;
    private float currentHP;
    private Animator anim;
    private bool dead;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHP = startingHP;
        anim = GetComponent<Animator>();
    }

    private  void TakeDamage(float _damage)
    {
        currentHP = Mathf.Clamp(currentHP - _damage, 0, startingHP);

        if (currentHP > 0)
        {

            //Player hurt
        }
        else
        {
            if(!dead)
            {

                if(GetComponentInParent<EnemyPatrol>() !=null)
                //Player dead
                GetComponentInParent<EnemyPatrol>().enabled = false;

                if(GetComponent<Centipede>()!=null)
                GetComponent<Centipede>().enabled = false;
                dead = true;
            }

            
        }
    }
}
