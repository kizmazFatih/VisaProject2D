using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private Detector detector;

    public GameObject coinPrefab;


    private Transform player;
    private Animator animator;
    private bool isFlipped = false;

    [HideInInspector]
    public bool death = false;

    [Header("Enemy Specials")]
    public float health = 100;



    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        detector = transform.GetChild(0).GetComponent<Detector>();
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFlipped = true;
        }
    }


    public void TakeDamage(float damageAmount)
    {
        animator.SetTrigger("Damaged");
        health -= damageAmount;
        if (detector.chasing == false)
        {
            detector.chasing = true;
        }
        if (health <= 0)
        {
            death = true;
            animator.SetBool("Death", death);

        }
    }

    void DropCoin()
    {
        int coinAmount = Random.Range(1, 3);
        for (int i = 0; i < coinAmount; i++)
        {
            Instantiate(coinPrefab, transform.position, Quaternion.identity);
        }
    }

    public void SetAtack()
    {
        animator.SetBool("Attack", false);
        if (Movement.instance.contact)
        {
            CharacterHealth.instance.TakeDamage(20f);
        }
    }

    public void Death()
    {
        DropCoin();
        Destroy(this.gameObject);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "FirePunch")
        {
            TakeDamage(50);
            Destroy(other.gameObject);
        }

    }
}
