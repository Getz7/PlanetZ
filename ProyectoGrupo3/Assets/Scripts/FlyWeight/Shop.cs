using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{

    public string itemName;
    public int itemPrice;
    public PlayerController playerController;
    public GameManager gameManager;
  
    private static Dictionary<string, FlyWeight> itemFlyweights = new Dictionary<string, FlyWeight>();

  

    private void Start()
    {

        gameManager = FindObjectOfType<GameManager>();
        playerController = FindObjectOfType<PlayerController>();

        FlyWeight flyweight = itemFlyweights[itemName];
        Debug.Log("Item: " + flyweight.itemName + ", Price: " + flyweight.itemPrice);
    }
    private void Awake()
    {
        
        if (!itemFlyweights.ContainsKey(itemName))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            FlyWeight flyweight = new FlyWeight(itemName, spriteRenderer.sprite, itemPrice);
            itemFlyweights.Add(itemName, flyweight);
        }
    }
    private void OnMouseDown()
    {
        if (itemFlyweights.ContainsKey(itemName))
        {
            FlyWeight flyweight = itemFlyweights[itemName];

            Decorator decorator = CreateDecorator();
            if (decorator != null)
            {
                GameManager.Instance.AddPurchasedDecorator(decorator); // Agrega el decorador al GameManager
                Debug.Log("Item purchased: " + flyweight.itemName);
            }
            else
            {
                Debug.Log("No se encontró un decorador válido para el ítem " + flyweight.itemName);
            }
        }
    }
    private Decorator CreateDecorator()
    {
        switch (itemName)
        {
            case "Vida":
                Debug.Log("Se compró daño");
                return new jumpBoostDecorator(2f); // Aumentar salto en 2
            case "Jugo de Frutos":
                Debug.Log("Se compró jugo de frutos");
                return new SpeedBoostDecorator(1000f); // Aumentar velocidad en 2
            case "CyberFrutos":
                Debug.Log("Se compró Cyberfrutos");
                return new jumpBoostDecorator(2f); // Aumentar daño en 2
            case "Jugos Monstruosos":
                Debug.Log("Se compró Jugo Monstruosos");
                return new ConcreteDeco(3); // Aumentar velocidad en 3
            case "Contenedor de corazon":
                Debug.Log("Se compró Contenedor de Corazon");
                return new SpeedBoostDecorator(3f); // Aumentar vida en 3
            default:
                Debug.Log("Ítem desconocido: " + itemName);
                return null;
        }
    }

}
