using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    public float velocidadTerminal = -20f;
    private Rigidbody2D _rig;
    public GameObject[] objetosdesactivar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.gameObject.GetComponent<PlayerController>().isStomping)
            {
                _rig = collision.gameObject.GetComponent<Rigidbody2D>();
                if (_rig.velocity.y <= velocidadTerminal)
                {
                    //Paso 1 romper la caja
                    //Paso 2 Reproducir un sonido
                    // Paso 3 reproducir una animacionetsplit
                    
                    for (int j = 0; j < objetosdesactivar.Length; j++)
                    {
                        objetosdesactivar[j].SetActive(false);
                    }
                    Destroy(this.gameObject);
                }
            }

        }
    }
}
