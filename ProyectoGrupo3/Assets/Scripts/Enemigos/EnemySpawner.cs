using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] private Enemy_Factory _enemyFac;
    [SerializeField] private GameObject[] spawns; // Se usara para facilitar la posicion de los enemigos.






    // Start is called before the first frame update
    private void Start()
    {
        

        //LLamamos a la factoria para crear los enemigos 
        

        _enemyFac.CreateEnemy("Centipede", new Vector2(41, -79));
        _enemyFac.CreateEnemy("Centipede", new Vector2(101, -101));

        _enemyFac.CreateEnemy("Volador", new Vector2(90, -74));
        _enemyFac.CreateEnemy("Volador", new Vector2(99, -74));
        _enemyFac.CreateEnemy("Torreta", new Vector2(101, -78));


        _enemyFac.CreateEnemy("BigBloated", new Vector2(15, -80));
        

    }

    
}
