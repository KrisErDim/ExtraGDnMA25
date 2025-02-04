using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform companion;  // Reference to the Companion
    public float speed; // Movement speed

    void Update()
    {
        // Move toward the Companion
        transform.position = Vector3.MoveTowards(transform.position, companion.position, speed * Time.deltaTime);
    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     // Check if the enemy touches the Companion
    //     if (collision.gameObject.CompareTag("Companion"))
    //     {
    //         FindObjectOfType<GameManager>().GameOver(); // Call GameOver
    //     }
    // }
}
