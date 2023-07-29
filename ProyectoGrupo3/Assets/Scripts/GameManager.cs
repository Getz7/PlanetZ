using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int contadorEnemies = 0;
    private PlayerController player;
    public HUD hud;






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
        if (contadorEnemies >= 5)
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
