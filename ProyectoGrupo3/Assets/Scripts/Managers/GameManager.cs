using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }


    private int contadorEnemies = 0;
    private List<Decorator> purchasedDecorators = new List<Decorator>();
    private PlayerController player;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
      private int puntosOxigeno;






   private void Start()
    {
    player = FindObjectOfType<PlayerController>();
    ApplyStoredDecorators();
    }
    private void ApplyStoredDecorators()
    {
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            foreach (Decorator decorator in purchasedDecorators)
            {
                decorator.ApplyDecorator(player);
            }
        }
    }
    public void AddPurchasedDecorator(Decorator decorator)
    {
        purchasedDecorators.Add(decorator);
    }
    public void EnemigoDestruido()
    {
        // Resto de tu código para contar enemigos...

        if (contadorEnemies >= 5)
        {
            player.ActiveSpecial(true);
            contadorEnemies = 0;
        }
    }


  
}