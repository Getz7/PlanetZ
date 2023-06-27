using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBloater_spawner : MonoBehaviour
{
    public Transform spawnPoint;
    private SpriteRenderer enemySprite;
    public Sprite model;
    // Start is called before the first frame update
    void Start()
    {
        GameObject bloatedObj = new GameObject("BigBloated");
        bloatedObj.transform.position = spawnPoint.position;
        bloatedObj.AddComponent<BigBloated>();


        enemySprite = bloatedObj.AddComponent<SpriteRenderer>();

        enemySprite.sortingLayerName = "player";
        enemySprite.sprite = model;
    }

    
}
