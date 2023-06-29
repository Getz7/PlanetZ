using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorKey : MonoBehaviour
{
    public Color colorObjeto;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jugador tiene la llave");
            PlayerData playerData = other.gameObject.GetComponent<PlayerData>();
            EventManager.Instance.KeyCollected(colorObjeto);
            playerData.AddColorKey(colorObjeto);
            Destroy(gameObject);
        }
    }

}
