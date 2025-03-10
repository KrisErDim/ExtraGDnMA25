using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform companion;  // Reference to the Companion
    public float speed; // Movement speed
    public int maxHealth; 
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        // Move toward the Companion
        transform.position = Vector3.MoveTowards(transform.position, companion.position, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
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
        if (currentHealth <= 0)
        {
            Destroyed();
        }
    }
    void Destroyed()
    {
        Destroy(gameObject); 
    }
}
