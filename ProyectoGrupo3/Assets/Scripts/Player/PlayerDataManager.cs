using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    private static PlayerDataManager _instance;
    public static PlayerDataManager Instance { get { return _instance; } }

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

    public void UpdatePuntosOxigeno(int newPuntos)
    {
        puntosOxigeno = newPuntos;
        
    }

    public int GetPuntosOxigeno()
    {
        return puntosOxigeno;
    }

    private void OnEnable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        
    }
}
