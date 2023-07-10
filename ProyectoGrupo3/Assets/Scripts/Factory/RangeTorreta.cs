using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTorreta : MonoBehaviour
{
    public Torreta turret;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (turret.facingRight)
            {
                turret.Attack(true);
            }
            else
            {
                turret.Attack(false);
            }
        }
    }
}
