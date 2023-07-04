using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerController player;
    public int enemyDamage = 1;

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player != null)
            {
                player.Hurt(enemyDamage);
            }
        }

    }
}