using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    private int contadorEnemies = 0;
    private PlayerController player;

    





    private void Start()
    {
        if (FindObjectOfType<PlayerController>() != null)
        {
            player = FindObjectOfType<PlayerController>();
        }

       


        



    }


    public void EnemigoDestruido()
    {
        contadorEnemies++;
        if (contadorEnemies >= 10)
        {
            player.ActiveSpecial(true);
            //if (player != null)
            //{
            // player.Aplauso();
            //}
            contadorEnemies = 0;
        }
    }
}
