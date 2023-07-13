using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyWeight
{
    public string itemName;
   
    public int itemPrice;

    // Constructor
    public FlyWeight(string name, Sprite sprite, int price)
    {
        itemName = name;
      
        itemPrice = price;
    }
}
