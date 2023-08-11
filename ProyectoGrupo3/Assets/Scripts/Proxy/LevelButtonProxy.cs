using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonProxy : MonoBehaviour, ILevelButton
{
    public int levelNumber;
    private ILevelButton realButton;

    private void Start()
    {
        realButton = GetComponent<ILevelButton>();
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        // Load completed levels from PlayerPrefs
        string levelsString = PlayerPrefs.GetString("CompletedLevels");
        string[] levelStrings = levelsString.Split(',');

        HashSet<int> completedLevels = new HashSet<int>();
        foreach (string level in levelStrings)
        {
            int completedLevel;
            if (int.TryParse(level, out completedLevel))
            {
                completedLevels.Add(completedLevel);
            }
        }

        // Check if the current level is completed
        if (completedLevels.Contains(levelNumber))
        {
            realButton.Enable();
           
        }
        else
        {
            realButton.Disable();
           
        }
    }

    public void Enable()
    {
        realButton.Enable();
    }

    public void Disable()
    {
        realButton.Disable();
    }
}
