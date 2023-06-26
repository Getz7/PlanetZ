using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface Factory_Pattern_Enemy 
{
    public Centipede createCentipede(int hp, int dmg, string type, float speed);
   
}
