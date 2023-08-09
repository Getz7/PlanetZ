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
        Debug.Log("NextLvl: Trigger entered");

        if (other.tag == "Player")
        {
           
           
            lvlManager.MarkLevelCompleted(levelNumber);
            Debug.Log("NextLvl: Level " + levelNumber + " completed! Switching scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}