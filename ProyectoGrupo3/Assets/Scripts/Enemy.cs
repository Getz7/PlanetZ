using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // common propperties
    public int hp { get; set; }
    public int dmg { get; set; }
    public float speed { get; set; }


   

  
   

    


    public abstract void UpdateEnemy();
    public abstract void DrawEnemy();

    public abstract void Attack();
    


    protected void TakeDmg(int dmg)
    {

    }

    protected void Die()
    {

    }
}
