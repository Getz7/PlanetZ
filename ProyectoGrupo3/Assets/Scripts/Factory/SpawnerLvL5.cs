using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLvL5 : MonoBehaviour
{

    [SerializeField] private Enemy_Factory _enemyFac;
    [SerializeField] private GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        _enemyFac.CreateEnemy("Centipede", new Vector2(spawns[0].transform.position.x, spawns[0].transform.position.y));
    }

    
}
