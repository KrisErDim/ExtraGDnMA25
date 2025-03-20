using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Called when the game is over
    public void GameOver()
    {
        UIManager.Instance.ShowGameOver();
        Time.timeScale = 0f; // Pause the game
    }

    // Restart the current level
    public void Retry()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    // Load the Main Menu scene
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene("MainMenu"); // Load main menu scene
    }

    // Load the Game Scene when starting a new game
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Load the game scene
    }

    // Quit the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!"); // Works in built game
    }
}
