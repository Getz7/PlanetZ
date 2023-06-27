using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Factory : MonoBehaviour
{
   public Enemy CreateEnemy(string enemyType)
    {
        switch (enemyType)
        {
            case "Centipede":
                return new Centipede();
            case "BigBloated":
                return new BigBloated();
            default:
                throw new ArgumentException("Invalid enemy type: " + enemyType);
        }
    }
   
    
        

      

    
}
