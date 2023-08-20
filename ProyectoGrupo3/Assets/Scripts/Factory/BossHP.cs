using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : EnemyHealth
{
    private Boss b;
    private Enemy _enemy;
    [SerializeField] private GameObject key;
    private bool hasDroppedKey = false;
    // Start is called before the first frame update
    void Start()
    {
        b = FindObjectOfType<Boss>();
        _enemy = FindObjectOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_EHealthPoints <= 0 && !hasDroppedKey)
        {
            hasDroppedKey = true; 
            FindObjectOfType<GameManager>().EnemigoDestruido();
            if (key != null) Instantiate(key, this.transform.position, Quaternion.identity);
        }
        speedUp();
    }

    public void speedUp()
    {
        if (_EHealthPoints < 8)
        {
            //b.MoveSpeed = 4;
        }
       
    }
}
