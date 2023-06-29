using UnityEngine;
using System;
using System.Collections.Generic;
//SUJETO CONCRETO

public class EventManager : MonoBehaviour, ISubject
{
    private static EventManager instance;
    private List<IObserver> observers = new List<IObserver>();
    public Color CollectedKeyColor { get; private set; }
    public event Action<Color> OnKeyCollected;
    public event Action OnDoorOpened;

    public void RegisterObserver(IObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }

    public void RemoveObserver(IObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.Updated(this);
        }
    }

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventManager>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<EventManager>();
                    singletonObject.name = "EventManager (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    

    public void KeyCollected(Color color)
    {
        CollectedKeyColor = color; 
        OnKeyCollected?.Invoke(color);
        NotifyObservers();
    }

    public void DoorOpened()
    {
        OnDoorOpened?.Invoke();
    }
}
