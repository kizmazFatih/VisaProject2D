using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class RocketHand : MonoBehaviour
{
    Vector3 startPos;
    Vector3 maxPos;
    float t = 0f;
    int i = 0;
    float speed;


    void Start()
    {
        startPos = transform.position;
    }


    void Update()
    {

        maxPos = startPos + (transform.right * 3);

        if (t >= 1f)
        {
            speed = -3f;
        }
        else if (t <= 0f)
        {
            i++;
            if (i < 2)
            {
                speed = 3f;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        t += Time.deltaTime * speed;

        Vector2 position = Vector2.Lerp(startPos, maxPos, t);
        transform.position = position;

    }


}
