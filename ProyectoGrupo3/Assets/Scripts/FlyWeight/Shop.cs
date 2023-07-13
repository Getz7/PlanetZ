using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public string itemName;
    public int itemPrice;

    private static Dictionary<string, FlyWeight> itemFlyweights = new Dictionary<string, FlyWeight>();

    private void Awake()
    {
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
}