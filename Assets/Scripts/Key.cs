using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoBehaviour
{
    public GameObject keyPrefab;
    private int a = 0;


    void Update()
    {
        if (transform.GetComponent<Enemy>().death && a == 0)
        {
            Instantiate(keyPrefab, transform.position, Quaternion.identity);
            a++;
        }
    }
}
