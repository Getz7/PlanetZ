using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Producto
public abstract class Enemy 
{
    private int hp;
    private int dmg;
    private string type;
    private float speed;

    private Sprite model;

    public Enemy(int _hp, int _dmg, string _type, float _speed, Sprite _model)
    {
        hp = _hp;
        dmg = _dmg;
        type = _type;
        speed = _speed;
        model = _model;
    }

    public Enemy(int _hp, int _dmg, string _type, float _speed)
    {
        hp = 0;
        dmg = 0;
        type = "";
        speed = 0;
        
    }

    public Enemy()
    {
      

    }
}
