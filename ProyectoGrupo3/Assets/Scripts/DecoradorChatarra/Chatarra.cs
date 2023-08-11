using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Chatarra : MonoBehaviour
{
    [SerializeField] private int _pointsToAdd = 15;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null)
        {
           
            player.ApplyPoints(_pointsToAdd);
            gameObject.SetActive(false);
        }
    }

}
