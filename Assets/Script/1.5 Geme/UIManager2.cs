using UnityEngine;
using TMPro;
using UnityEngine.UI; // For UI elements like HP bars

public class UIManager2 : MonoBehaviour
{
    public static UIManager2 Instance; // Singleton reference

    public TextMeshProUGUI coinCountText; // Coin count UI
    private int totalCoins = 0; // Track total coins
    public GameObject gameOverScreen;

    void Awake()
    {
        Instance = this; // Set the instance so other scripts can access it
    }

    void Start()
    {
        gameOverScreen.SetActive(false); // Hide Game Over panel at start
        UpdateCoinUI(); // Initialize coin UI
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true); // Show Game Over UI
    }

    // Add coins & update UI
    public void AddCoin(int amount)
    {
        totalCoins += amount;
        UpdateCoinUI();
    }

    // Update Coin UI
    private void UpdateCoinUI()
    {
        if (coinCountText != null)
        {
            coinCountText.text = "Coins: " + totalCoins;
        }
    }
}
