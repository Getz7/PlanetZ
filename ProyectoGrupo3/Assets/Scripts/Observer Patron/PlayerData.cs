using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//OBSERVADOR CONCRETO

public class PlayerData : MonoBehaviour, IObserver
{
    public List<Color> colorKeys = new List<Color>();

    private void Start()
    {
        EventManager.Instance.RegisterObserver(this);
        EventManager.Instance.OnDoorOpened += ResetKeys;
    }

    public void Updated(ISubject subject)
    {
        if (subject is EventManager eventManager)                               
        {

            Debug.Log("Key collected! Color: " + eventManager.CollectedKeyColor);
        }
    }

    public bool HasColorKey(Color color)
    {
        return colorKeys.Contains(color);
    }

    public void AddColorKey(Color color)
    {
        if (!HasColorKey(color))
        {
            colorKeys.Add(color);
        }
    }


    private void ResetKeys()
    {
        colorKeys.Clear();
    }

}
