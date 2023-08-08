using UnityEngine;

public class IPlayerData : MonoBehaviour
{
    private void Start()
    {
        PlayerDataManager.Instance.LoadPlayerData();
    }
}
