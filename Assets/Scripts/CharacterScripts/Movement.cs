using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    public Transform startPoint;
    public GameObject prefab_fire;
    private Animator animator;


    private float horizontal;
    public bool contact = false;
    public bool gameEnded = false;

    private bool hasKey = false;

    private GameObject currentEnemy;

    public GameObject warningTextPrefab;
    public GameObject keyImage;


    [Header("Player Specials")]
    public float speed;

    public bool canJump = false;
    public int coin = 0;

    public bool firePunchActive = false;




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

        transform.position = startPoint.position;
        keyImage.SetActive(false);
    }


    void Update()
    {
        Move();
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
    void Punch()
    {
        if (Input.GetKeyDown(KeyCode.E) && !punch.instance.IsPunchAnimPlaying)
        {
            animator.SetTrigger("punch");

        }

    }

    public void ApplyDamage()
    {

        if (contact)
        {
            if (currentEnemy != null)
            {
                currentEnemy.GetComponent<Enemy>().TakeDamage(35);
            }
        }
    }



    void FirePunch()
    {

        if (Input.GetKeyDown(KeyCode.Q) & firePunchActive)
        {
            animator.SetTrigger("firepunch");
            Instantiate(prefab_fire, transform.position, transform.rotation);
        }
    }








    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coin++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            contact = true;
            currentEnemy = other.transform.parent.gameObject;
        }
        if (other.gameObject.tag == "DeathZone")
        {
            CharacterHealth.instance.death = true;
            animator.SetBool("Death", true);
        }
        if (other.gameObject.tag == "Key")
        {
            hasKey = true;
            keyImage.SetActive(true);
            Destroy(other.gameObject);


        }
        if (other.gameObject.tag == "End")
        {
            if (hasKey)
            {
                gameEnded = true;
            }
            else
            {
                Instantiate(warningTextPrefab, warningTextPrefab.transform.position + new Vector3(600, 0, 0), Quaternion.identity, GameObject.Find("ScreenUI").transform);
            }

        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            contact = false;
        }
    }



}
