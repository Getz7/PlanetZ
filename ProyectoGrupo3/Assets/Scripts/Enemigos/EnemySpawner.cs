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
        

        _enemyFac.CreateEnemy("Centipede", new Vector2(spawns[0].transform.position.x, spawns[0].transform.position.y));
        _enemyFac.CreateEnemy("Volador", new Vector2(spawns[1].transform.position.x, spawns[1].transform.position.y));
        _enemyFac.CreateEnemy("Centipede", new Vector2(spawns[2].transform.position.x, spawns[2].transform.position.y));
        _enemyFac.CreateEnemy("Volador", new Vector2(spawns[3].transform.position.x, spawns[3].transform.position.y));
        _enemyFac.CreateEnemy("Volador", new Vector2(spawns[4].transform.position.x, spawns[4].transform.position.y));
        _enemyFac.CreateEnemy("Chancho", new Vector2(spawns[5].transform.position.x, spawns[5].transform.position.y));
        _enemyFac.CreateEnemy("Centipede", new Vector2(spawns[6].transform.position.x, spawns[6].transform.position.y));
        _enemyFac.CreateEnemy("Chancho", new Vector2(spawns[7].transform.position.x, spawns[7].transform.position.y));
        _enemyFac.CreateEnemy("Volador", new Vector2(spawns[8].transform.position.x, spawns[8].transform.position.y));
        




    }

    
}
