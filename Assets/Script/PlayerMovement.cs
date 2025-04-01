using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Camera mainCamera;
    SpriteRenderer sr;
    Animator am;
    Vector3 MoveDir;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"));
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(MoveDir.x * speed, MoveDir.y * speed, 0);
    }

    // Update is called once per frame
    void Update()
    {   
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        MoveDir = new Vector3(moveX, moveY, 0).normalized;

        // Camera follow
        if (mainCamera != null)
        {
            mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f);
        }

        float playerX = transform.position.x;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //flip to mouse
        if (mousePos.x < playerX)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }

        //moving
        if(MoveDir.x != 0 || MoveDir.y != 0)
        {
            am.SetBool("Move", true);
        }
        else
        {
            am.SetBool("Move", false);
        }
    }
}
