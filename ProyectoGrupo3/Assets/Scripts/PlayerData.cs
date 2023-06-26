using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public List<Color> colorKeys = new List<Color>();

    private void Start()
    {
        EventManager.Instance.OnDoorOpened += ResetKeys;
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
