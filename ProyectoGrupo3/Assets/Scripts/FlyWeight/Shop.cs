using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public string itemName;
    public int itemPrice;
    private DecoratorData decoratorDataInstance; 
    private static Dictionary<string, FlyWeight> itemFlyweights = new Dictionary<string, FlyWeight>();

    private void Awake()
    {
        decoratorDataInstance = new DecoratorData();
        if (!itemFlyweights.ContainsKey(itemName))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            FlyWeight flyweight = new FlyWeight(itemName, spriteRenderer.sprite, itemPrice);
            itemFlyweights.Add(itemName, flyweight);
        }
    }

    private void Start()
    {
        FlyWeight flyweight = itemFlyweights[itemName];
        Debug.Log("Item: " + flyweight.itemName + ", Price: " + flyweight.itemPrice);
    }

    private void OnMouseDown()
    {
        if (itemFlyweights.ContainsKey(itemName))
        {
            FlyWeight flyweight = itemFlyweights[itemName];

            Decorator decorator = CreateDecorator();
            if (decorator != null)
            {
                decoratorDataInstance.AddItemToInventory(flyweight);
                Debug.Log("Item purchased: " + flyweight.itemName);
            }
            else
            {
                Debug.Log("No se encontr� un decorador v�lido para el �tem " + flyweight.itemName);
            }
        }
    }

    private Decorator CreateDecorator()
    {
        switch (itemName)
        {
            case "Vida":
                Debug.Log("Se compr� vida");
                return new ConcreteDeco(1); // Aumentar vida en 1
            case "Jugo de Frutos":
                Debug.Log("Se compr� jugo de frutos");
                return new SpeedBoostDecorator(2); // Aumentar velocidad en 2
            case "CyberFrutos":
                Debug.Log("Se compr� Cyberfrutos");
                return new ConcreteDeco(2); // Aumentar vida en 2
            case "Jugos Monstruosos":
                Debug.Log("Se compr� Jugo Monstruosos");
                return new SpeedBoostDecorator(3); // Aumentar velocidad en 3
            case "Contenedor de corazon":
                Debug.Log("Se compr� Contenedor de Corazon");
                return new ConcreteDeco(3); // Aumentar vida en 3
            default:
                Debug.Log("�tem desconocido: " + itemName);
                return null;
        }
    }

}
