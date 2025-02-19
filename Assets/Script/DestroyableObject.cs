using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableObject : MonoBehaviour
{
    public int maxHealth; 
    private int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
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
