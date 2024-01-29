using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 20f;

    private Rigidbody2D rb;

    [SerializeField] private float speed = 7f;

    bool isGrounded;
    float jumpCoolDown;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rb.velocity.y);

        jumpCoolDown += Time.deltaTime;

        if(HorizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if(HorizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown("w") && isGrounded && jumpCoolDown > 0.5f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpSpeed, 0);
            isGrounded=false;
            jumpCoolDown = 0;
        }
        isGrounded = true;

    }
    
}
