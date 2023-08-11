using UnityEngine;

public class ResetLevelData : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearCompletedLevels();
        }
    }

    public void ClearCompletedLevels()
    {
        // Clear the completed levels data
        PlayerPrefs.DeleteKey("CompletedLevels");
       
    }
}
