using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform companion;  // Reference to the Companion
    public float speed; // Movement speed
    public int maxHealth; 
    private int currentHealth;

    public GameObject hpBarGreen;  // The green HP bar (current health)
    public GameObject hpBarRed;  // The red HP bar (full health background)
    public Vector3 hpBarOffset = new Vector3(0f, 1f, 0f);  // Adjust the offset for HP bar above the enemy
    public GameObject coinPrefab; 

    void Start()
    {
        if (companion == null) 
        {
            companion = GameObject.FindGameObjectWithTag("Companion")?.transform;
            if (companion == null)
            {
                Debug.LogError("Companion not found! Make sure your companion has the correct tag.");
            }
        }
        currentHealth = maxHealth;

        if (hpBarGreen != null && hpBarRed != null)
        {
            hpBarGreen.SetActive(false);  // Hide the green bar initially
            hpBarRed.SetActive(false);  // The red bar is always visible
        }
    }

    void Update()
    {    
        // Move toward the Companion
        transform.position = Vector3.MoveTowards(transform.position, companion.position, speed * Time.deltaTime);
        
        // Position the HP bar above the enemy (since it's a child, no need for WorldToScreenPoint)
        if (hpBarGreen != null && hpBarRed != null)
        {
            hpBarGreen.transform.position = transform.position + hpBarOffset;
            hpBarRed.transform.position = transform.position + hpBarOffset;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
            Debug.Log("Hit");
        }

    }
    void TakeDamage()
    {
        currentHealth--;


        // Show the HP bar if health is not full or after taking damage
        if (hpBarGreen != null && hpBarRed != null)
        {
            hpBarGreen.SetActive(true);  // Show the green bar
            hpBarRed.SetActive(true);
            UpdateHpBar();  // Update HP bar size
            
            if (currentHealth <= 0)
            {
                Destroyed();
            }
        }
    }

    private void UpdateHpBar()
    {
        if (hpBarGreen != null)
        {
            // Update the green bar's width based on the current health
            float healthPercentage = (float)currentHealth / maxHealth;
            Vector3 scale = hpBarGreen.transform.localScale;
            scale.x = healthPercentage;  // Adjust the width of the green bar
            hpBarGreen.transform.localScale = scale;
        }
    }
    void Destroyed()
    {
        UIManager.Instance.KillCount(); // Update UI
        
        // Drop a coin when the enemy dies
        if (coinPrefab != null)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }
}

