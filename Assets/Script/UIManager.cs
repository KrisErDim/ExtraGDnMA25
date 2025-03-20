using UnityEngine;
using TMPro;
using UnityEngine.UI; // For UI elements like HP bars

public class UIManager : MonoBehaviour
{
    public static UIManager Instance; // Singleton reference

    public TextMeshProUGUI killCountText; // Kill count UI
    private int killCount = 0; // Track total kills

    public TextMeshProUGUI coinCountText; // Coin count UI
    private int totalCoins = 0; // Track total coins

    public Image companionHPBar; // Companion HP bar UI
    
    public GameObject gameOverScreen;

    void Awake()
    {
        Instance = this; // Set the instance so other scripts can access it
    }

    void Start()
    {
        gameOverScreen.SetActive(false); // Hide Game Over panel at start
        
        UpdateCoinUI(); // No need for a parameter
        UpdateKillCount();
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true); // Show Game Over UI
    }

    // Call this when an enemy dies
    public void KillCount()
    {
        killCount++;
        UpdateKillCount();
    }

    // Update Kill Count UI
    private void UpdateKillCount()
    {
        if (killCountText != null)
        {
            killCountText.text = "Kills: " + killCount;
        }
    }

    // Update Companion HP Bar
    public void UpdateCompanionHP(float currentHealth, float maxHealth)
    {
        if (companionHPBar != null)
        {
            companionHPBar.fillAmount = currentHealth / maxHealth; // Set HP bar fill
        }
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
