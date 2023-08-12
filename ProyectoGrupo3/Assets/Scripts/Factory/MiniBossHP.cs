using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossHP : EnemyHealth
{
    [SerializeField] private GameObject key;
    // Start is called before the first frame update
    private bool hasDroppedKey = false; 
    void Start()
    {

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
    }
}
