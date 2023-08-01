using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private Enemy_Factory _enemyFac;
    
   

    
    

    // Start is called before the first frame update
    private void Start()
    {
        

        //LLamamos a la factoria para crear los enemigos 
        

        _enemyFac.CreateEnemy("Centipede", new Vector2(41, -79));
        _enemyFac.CreateEnemy("Centipede", new Vector2(101, -101));
       




        _enemyFac.CreateEnemy("BigBloated", new Vector2(15, -80));
        

    }

    
}
