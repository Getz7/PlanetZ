using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    public int itemPrice;

    private static Dictionary<string, FlyWeight> itemFlyweights = new Dictionary<string, FlyWeight>();

    private void Awake()
    {
      
        if (!itemFlyweights.ContainsKey(itemName))
        {
            FlyWeight flyweight = new FlyWeight(itemName, itemSprite, itemPrice);
            itemFlyweights.Add(itemName, flyweight);
        }
    }

    private void Start()
    {
       
        FlyWeight flyweight = itemFlyweights[itemName];

        Debug.Log("Item: " + flyweight.itemName + ", Price: " + flyweight.itemPrice);
    }
}