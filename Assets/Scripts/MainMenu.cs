using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private string saveFilePath;

    void Start()
    {
        // Set the save file path to the same location used for saving
        saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.txt");
    }

    // This method is called when the Play button is clicked
    public void PlayGame()
    {
        // Load Level1 or the initial game level
        SceneManager.LoadScene("Level1");
    }

    // This method is called when the Load button is clicked
    public void LoadGame()
    {
        // Check if the save file exists
        if (File.Exists(saveFilePath))
        {
            // Read the saved data from the file
            string json = File.ReadAllText(saveFilePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // Load the saved level from the saved data
            string savedLevel = data.levelName;
            if (!string.IsNullOrEmpty(savedLevel))
            {
                SceneManager.LoadScene(savedLevel);
                StartCoroutine(LoadPlayerPosition(data.playerPosition)); // Load the player position after the level is loaded
            }
            else
            {
                Debug.Log("No saved level found.");
            }
        }
        else
        {
            Debug.Log("No save file found.");
        }
    }

    // Coroutine to load player position after the level is fully loaded
    private IEnumerator LoadPlayerPosition(Vector3 position)
    {
        yield return new WaitForSeconds(0.5f); // Wait for the scene to load
        GameObject player = GameObject.Find("Player"); // Ensure your player GameObject is named "Player"
        if (player != null)
        {
            player.transform.position = position;
            Debug.Log("Player position loaded: " + position);
        }
        else
        {
            Debug.Log("Player not found.");
        }
    }

    // This method is called when the Exit button is clicked
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");  // For testing in the editor
    }

    // Method to save the current game state (level and player position)
    public void SaveGame(string currentLevel)
    {
        SaveData data = new SaveData();
        data.levelName = currentLevel; // Save the current level name

        GameObject player = GameObject.Find("Player"); // Find your player GameObject
        if (player != null)
        {
            data.playerPosition = player.transform.position; // Save the player's current position
        }
        else
        {
            Debug.Log("Player not found, cannot save position.");
            return;
        }

        // Convert game data to JSON and save it to a file
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);

        Debug.Log("Game saved at level: " + currentLevel + " with position: " + data.playerPosition);
    }
}

// Class for saving game data
[System.Serializable]
public class SaveData
{
    public Vector3 playerPosition; // To save player's position
    public string levelName; // To save the current level name
}
