using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement; // Make sure this is included

public class MenuController : MonoBehaviour
{
    public GameObject menuPanel;  // A panel containing the Resume, Save, and Exit buttons
    public Button menuButton;     // The Menu button

    private bool isGamePaused = false;

    void Start()
    {
        // Initially hide the menu panel
        menuPanel.SetActive(false);

        // Add listeners for the Menu button to show the menu when clicked
        menuButton.onClick.AddListener(ShowMenu);
    }

    // Show the menu and pause the game
    void ShowMenu()
    {
        menuPanel.SetActive(true);
        PauseGame();
    }

    // Called when the Resume button is clicked
    public void ResumeGame()
    {
        menuPanel.SetActive(false);
        UnpauseGame();
    }

    // Called when the Save button is clicked
    public void SaveGame()
    {
        // Call SaveGame from MainMenu
        MainMenu mainMenu = FindObjectOfType<MainMenu>();
        if (mainMenu != null)
        {
            string currentLevel = SceneManager.GetActiveScene().name; // Get current level name
            mainMenu.SaveGame(currentLevel); // Save game state
        }
    }

    // Called when the Exit button is clicked
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    // Pause the game (stop time)
    void PauseGame()
    {
        Time.timeScale = 0; // Freezes the game
        isGamePaused = true;
    }

    // Unpause the game (resume time)
    void UnpauseGame()
    {
        Time.timeScale = 1; // Resumes the game
        isGamePaused = false;
    }
}
