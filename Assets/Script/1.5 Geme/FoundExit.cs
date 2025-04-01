using UnityEngine;

public class FoundExit: MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Finish"))  
        {
            Time.timeScale = 0f; // Pause the game
            GameOver();
        }
    }

    public void GameOver()
    {
        UIManager2.Instance.ShowGameOver();
        Time.timeScale = 0f; // Pause the game
    }
}
