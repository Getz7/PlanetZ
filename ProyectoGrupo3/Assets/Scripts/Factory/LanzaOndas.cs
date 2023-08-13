using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanzaOndas : MonoBehaviour
{
    public bool dentroDeAreaOndas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dentroDeAreaOndas = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dentroDeAreaOndas = false;
        }

    }
}
