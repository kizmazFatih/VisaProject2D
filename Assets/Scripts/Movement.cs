using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    public GameObject prefab_fire;
    private Animator animator;
    private Rigidbody2D rb;

    private float horizontal;


    [Header("Player Specials")]
    public float speed;

    public bool canJump = false;
    public int coin = 0;




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Move();
        Jump();
        Punch();
        FirePunch();
    }


    void Move()
    {
        horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("horizontal", Mathf.Abs(horizontal));


        #region rotate character
        if (horizontal > 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontal < 0)
        {

            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        #endregion


        transform.Translate(transform.right * horizontal * speed * Time.deltaTime);


    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            animator.SetTrigger("jump");
        }
    }
    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.E) && !punch.instance.IsPunchAnimPlaying)
        {
            animator.SetTrigger("punch");
        }
    }

    void FirePunch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("firepunch");
        }
    }


    public void FirePunchAnimationEvent()
    {

        Instantiate(prefab_fire, transform.position, transform.rotation);
    }








    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coin++;
            Destroy(other.gameObject);
        }
    }



}
