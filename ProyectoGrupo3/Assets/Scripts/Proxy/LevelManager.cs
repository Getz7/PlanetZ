using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private HashSet<int> completedLevels = new HashSet<int>();

    private void Start()
    {
        LoadCompletedLevelsFromPlayerPrefs();
    }

    public void MarkLevelCompleted(int levelNumber)
    {
        completedLevels.Add(levelNumber);
        SaveCompletedLevelsToPlayerPrefs();
        Debug.Log("Level " + levelNumber + " marked as completed.");
    }

    public bool IsLevelCompleted(int levelNumber)
    {
        bool isCompleted = completedLevels.Contains(levelNumber);
        Debug.Log("Level " + levelNumber + " is " + (isCompleted ? "completed" : "not completed"));
        return isCompleted;
    }

    public void SaveCompletedLevelsToPlayerPrefs()
    {
        string levelsString = string.Join(",", completedLevels);
        PlayerPrefs.SetString("CompletedLevels", levelsString);
    }

    public void LoadCompletedLevelsFromPlayerPrefs()
    {
        string levelsString = PlayerPrefs.GetString("CompletedLevels");
        string[] levelStrings = levelsString.Split(',');

        completedLevels.Clear();
        foreach (string level in levelStrings)
        {
            int completedLevel;
            if (int.TryParse(level, out completedLevel))
            {
                completedLevels.Add(completedLevel);
            }
        }
    }
}
