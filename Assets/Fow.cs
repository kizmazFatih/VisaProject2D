using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fow : MonoBehaviour
{
    public bool chasing = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 4)
        {
            chasing = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 3)
        {
            chasing = false;
        }
    }
}
