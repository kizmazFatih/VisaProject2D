using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public bool canJump = false;
    private Animator animator;
    private Rigidbody2D rb;



    void Start()
    {
        animator = transform.root.GetComponent<Animator>();
        rb = transform.root.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Jumping();
    }


    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * 7, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
        }

    }
}
