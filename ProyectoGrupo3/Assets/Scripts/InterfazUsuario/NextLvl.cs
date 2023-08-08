using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        print("Trigger entered");

        if (other.tag == "Player")
        {
            PlayerDataManager.Instance.SavePlayerData();
            lvlManager.MarkLevelCompleted(levelNumber);
            Debug.Log("Level " + levelNumber + " completed!");
            print("Switching scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }

    }
}
