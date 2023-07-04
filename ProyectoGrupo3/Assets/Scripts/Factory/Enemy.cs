using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    // common propperties
     public int _hp { get; set; }
     public int _dmg { get; set; }
     public float _speed { get; set; }

    [SerializeField] private string _type;

    //Get
    public string Type => _type;

     

    public Enemy(int hp, int dmg, float speed)
    {
        _hp = hp;
        _dmg = dmg;
        _speed = speed;
        
    }

    public Enemy()
    {

    }

    public abstract void Move();
    public abstract void DrawEnemy();

    public abstract void Attack();



    public  void TakeDmg()
    {

    }
    

    protected void Die()
    {

    }
}
