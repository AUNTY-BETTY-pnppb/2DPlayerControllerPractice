using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;

    bool isGrounded;
    [SerializeField]
    Transform groundCheck;

    public float speed = 2f;
    public float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            if (isGrounded)
                animator.Play("Player_run");

            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            if (isGrounded)
                animator.Play("Player_run");

            spriteRenderer.flipX = true;
        }
        else
        {
            if (isGrounded)
                animator.Play("Player_idle");
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
        }

        if (Input.GetKey("z") && isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpHeight);
            animator.Play("Player_jump");
        }
    }
}
