using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBloated : Enemy
{

    public BigBloated()
    {
        _hp = 8;
        _dmg = 5;
        _speed = 0.7f;
        
    }
   

    public override void Attack()
    {
        
    }

    public override void Awake()
    {
        throw new System.NotImplementedException();
    }

    public override void Move(int _direction)
    {

    }
    public override void DirecctionChange()
    {
        throw new System.NotImplementedException();
    }
}
