using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public int enemyDamage = 1;
    PlayerController player;
    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("la flecha impacto al jugador");
            

            player.Hurt(enemyDamage);

            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }
}
