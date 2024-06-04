using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector2 startPos;
    Vector2 lastPos;

    float maxDistance = 5;

    void Start()
    {
        startPos = transform.position;

    }


    void Update()
    {
        transform.Translate(Vector2.right * 6 * Time.deltaTime);

        lastPos = transform.position;
        float distance = Mathf.Abs(lastPos.x - startPos.x);

        if (distance >= maxDistance)
        {
            Destroy(this.gameObject);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterHealth.instance.TakeDamage(20);
            Destroy(this.gameObject);
        }
    }
}
