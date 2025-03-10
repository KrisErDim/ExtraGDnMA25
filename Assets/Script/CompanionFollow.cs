using UnityEngine;
using System.Collections;

public class CompanionFollow : MonoBehaviour
{
    public Transform player;  // Reference to the Player
    public float followSpeed; // Speed of following
    public float followDistance; // Distance threshold for following
    private int CompcurrentHealth;
    public int CompmaxHealth;
    private bool isInvincible = false; // Untuk cooldown hit
    public float invincibilityDuration = 1.5f; // Cooldown antar hit


    void Start()
    {
        CompcurrentHealth = CompmaxHealth; // Companion HP

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Companion"), LayerMask.NameToLayer("Player"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Companion"), LayerMask.NameToLayer("Bullet"));
    }
    void Update()
    {
        
        // Calculate distance between Companion and Player
        float distance = Vector3.Distance(transform.position, player.position);

        // If the distance is greater than the follow distance, move toward the player
        if (distance > followDistance)
        {
            Vector3 targetPosition = player.position;
            targetPosition.z = transform.position.z; // Optional, if 2D
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInvincible)
        {
            TakeDamage();
            Debug.Log("Companion Hit!");
        }
    }

    void TakeDamage()
    {
        CompcurrentHealth--;
        if (CompcurrentHealth <= 0)
        {
            Destroyed();
        }
        else
        {
            StartCoroutine(InvincibilityCooldown()); // Mulai cooldown
        }
    }
    IEnumerator InvincibilityCooldown()
    {
        isInvincible = true; // Companion kebal sementara
        yield return new WaitForSeconds(invincibilityDuration); // Tunggu cooldown selesai
        isInvincible = false; // Bisa kena hit lagi
    }
    void Destroyed()
    {
        Destroy(gameObject); 
        FindObjectOfType<GameManager>().GameOver();
    }
}
