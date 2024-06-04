using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed = 3;
    public float damage;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * transform.right);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            CharacterHealth.instance.TakeDamage(damage);
        }
        if (other.gameObject.tag == "Turner")
        {
            speed *= -1;
        }
    }
}
