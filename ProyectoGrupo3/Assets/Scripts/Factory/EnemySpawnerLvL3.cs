using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLvL3 : MonoBehaviour
{
    [SerializeField] private Enemy_Factory _enemyFac;

    [SerializeField] private GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        _enemyFac.CreateEnemy("Centipede", new Vector2(spawns[1].transform.position.x, spawns[1].transform.position.y) );

        
    }

   
}
