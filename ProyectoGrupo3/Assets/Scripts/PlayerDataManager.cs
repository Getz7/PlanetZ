using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private static PlayerDataManager _instance;

    public static PlayerDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PlayerDataManager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("PlayerDataManagerSingleton");
                    _instance = singletonObject.AddComponent<PlayerDataManager>();
                }
            }
            return _instance;
        }
    }

    public int puntosOxigeno;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("PuntosOxigeno", puntosOxigeno);
        PlayerPrefs.Save(); // Ensure data is saved immediately
    }

    public void LoadPlayerData()
    {
        puntosOxigeno = PlayerPrefs.GetInt("PuntosOxigeno", 0);
    }
}
