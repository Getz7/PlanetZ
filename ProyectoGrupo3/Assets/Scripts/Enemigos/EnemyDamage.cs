using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerController player;
    public int enemyDamage = 1;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    protected virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player != null)
            {
                Debug.Log("Enemy collided with player");
                player.Hurt(enemyDamage);
            }
        }

    }
}