using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public Camera mainCamera;

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(new Vector3(moveX, moveY, 0));

        // Camera follow
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f);
        }
    }
}
