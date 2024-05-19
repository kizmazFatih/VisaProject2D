using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 maxPos, minPos;

    private float speed = 1;
    public float t = 0f;

    void Start()
    {
        startPos = transform.position;
        maxPos = startPos + new Vector2(5, 0);

    }

    void Update()
    {

        /* if (transform.position.x >= maxPos.x || transform.position.x <= minPos.x)
         {
             speed *= -1;
         }*/
        if (t >= 1 || t <= 0)
        {
            speed *= -1;
        }



        t += Time.deltaTime * speed;

        // transform.Translate(Vector2.right * speed * Time.deltaTime);

        Vector2 targetPos = Vector2.Lerp(startPos, maxPos, t);
        transform.position = targetPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterHealth.instance.TakeDamage(15f);
        }
    }
}
