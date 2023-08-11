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
    public FlyWeight GetItemFlyweight(string itemName)
    {
        if (itemFlyweights.ContainsKey(itemName))
        {
            return itemFlyweights[itemName];
        }
        else
        {
           
            return null;
        }
    }
}
    


