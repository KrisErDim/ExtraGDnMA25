using UnityEngine;

public class CompanionFollow : MonoBehaviour
{
    public Transform player;  // Reference to the Player
    public float followSpeed; // Speed of following
    public float followDistance; // Distance threshold for following

    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Companion"), LayerMask.NameToLayer("Player"));
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
}
