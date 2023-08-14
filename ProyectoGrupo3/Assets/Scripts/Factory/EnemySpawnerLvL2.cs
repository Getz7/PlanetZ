using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerLvL2 : MonoBehaviour
{

    [SerializeField] private Enemy_Factory _enemyFac;
    [SerializeField] private GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        _enemyFac.CreateEnemy("Torreta", new Vector2(spawns[0].transform.position.x, spawns[0].transform.position.y));

        _enemyFac.CreateEnemy("Torreta", new Vector2(spawns[1].transform.position.x, spawns[1].transform.position.y));

        _enemyFac.CreateEnemy("BigBloated", new Vector2(spawns[2].transform.position.x, spawns[2].transform.position.y));
        _enemyFac.CreateEnemy("Volador", new Vector2(spawns[3].transform.position.x, spawns[3].transform.position.y));
        _enemyFac.CreateEnemy("Volador", new Vector2(spawns[4].transform.position.x, spawns[4].transform.position.y));



    }


}
