using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    private SpriteRenderer enemySprite;
    public Sprite model;



    // Start is called before the first frame update
    private void Start()
    {
        GameObject centipedeObj = new GameObject("Centipede");
        centipedeObj.transform.position = spawnPoint.position;
        centipedeObj.AddComponent<Centipede>();
        

        enemySprite = centipedeObj.AddComponent<SpriteRenderer>();

        enemySprite.sortingLayerName = "player";
        enemySprite.sprite = model;

        

    }

    
}
