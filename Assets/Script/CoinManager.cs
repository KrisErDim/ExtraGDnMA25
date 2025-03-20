using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coinValue = 1; // How much the coin is worth

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if player collects the coin
        {
            UIManager.Instance.AddCoin(coinValue); // Send coin data to UIManager
            Destroy(gameObject); // Remove coin after collection
        }
    }
}


