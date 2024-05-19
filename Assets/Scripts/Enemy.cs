using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy instance;

    public bool canDamageTake = false;

    [Header("Enemy Specials")]
    public float health = 100;

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


    void Update()
    {

    }


    public void TakeDamage(float damageAmount)
    {
        if (canDamageTake)
        {
            health -= damageAmount*Time.deltaTime;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canDamageTake = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            canDamageTake = false;
        }
    }
}
