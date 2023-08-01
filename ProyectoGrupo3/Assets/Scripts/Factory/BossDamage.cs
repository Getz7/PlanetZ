using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamage : EnemyDamage
{
    private BossHP hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = FindObjectOfType<BossHP>();
    }

    // Update is called once per frame
    void Update()
    {
        multiplyDamage();
    }

    public void multiplyDamage()
    {
        if (hp._EHealthPoints < 5)
        {

            enemyDamage = 8;
        }
    }
}
