using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : EnemyHealth
{
    private Boss b;
    // Start is called before the first frame update
    void Start()
    {
        b = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        speedUp();
    }

    public void speedUp()
    {
        if (_EHealthPoints < 8)
        {
            b.speed = 4;
        }
    }
}
