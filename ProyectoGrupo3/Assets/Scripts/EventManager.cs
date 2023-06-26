using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;

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

    public event Action<Color> OnKeyCollected;
    public event Action OnDoorOpened;

    public void KeyCollected(Color color)
    {
        OnKeyCollected?.Invoke(color);
    }

    public void DoorOpened()
    {
        OnDoorOpened?.Invoke();
    }
}
