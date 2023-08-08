using UnityEngine;

public class LoadData : MonoBehaviour
{
    private void Start()
    {
        PlayerDataManager.Instance.LoadPlayerData();
    }
}
