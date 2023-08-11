using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLvl : MonoBehaviour
{
    public int sceneBuildIndex;
    public int levelNumber;
    private LevelManager lvlManager;

    private void Start()
    {
        lvlManager = FindAnyObjectByType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       

        if (other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            int playerPoints = playerController.GetPoints();

         
            PlayerDataManager.Instance.UpdatePuntosOxigeno(playerPoints);

            lvlManager.MarkLevelCompleted(levelNumber);
            

        
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}