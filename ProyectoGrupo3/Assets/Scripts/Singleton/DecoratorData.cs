using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DecoratorData
{
    private static DecoratorData instance;

    public static DecoratorData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DecoratorData();
            }
            return instance;
        }
    }

    private List<FlyWeight> purchasedItems = new List<FlyWeight>();

    public void AddItemToInventory(FlyWeight item)
    {
     
        purchasedItems.Add(item);
        
    }

    public List<FlyWeight> GetPurchasedItems()
    {
       
        return purchasedItems;
        
    }
}


