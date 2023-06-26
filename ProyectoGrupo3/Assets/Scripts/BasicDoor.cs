using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class BasicDoor : MonoBehaviour
{
    public Tilemap doorTilemap;
    public List<Color> requiredColors = new List<Color>();
    public float moveDistance = 3f;
    private bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen && other.CompareTag("Player"))
        {
            Debug.Log("Jugador entro a la zona de la puerta");
            PlayerData playerData = other.GetComponent<PlayerData>();

            bool allColorsCollected = true;
            foreach (Color requiredColor in requiredColors)
            {
                if (!playerData.HasColorKey(requiredColor))
                {
                    allColorsCollected = false;
                    break;
                }
            }

            if (allColorsCollected)
            {
                OpenDoor();
            }
        }
    }

    private void OpenDoor()
    {
    
        EventManager.Instance.DoorOpened();

       
        foreach (Vector3Int doorTilePosition in doorTilemap.cellBounds.allPositionsWithin)
        {
            if (doorTilemap.HasTile(doorTilePosition))
            {
                doorTilemap.SetTile(doorTilePosition, null);
            }
        }

      
        transform.Translate(Vector3.down * moveDistance);

        isOpen = true;
    }

}
