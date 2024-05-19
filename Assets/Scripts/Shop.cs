using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool isShopOpen = false;
    public GameObject shopCanvas;

    private bool checker = false;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && checker)
        {
            if (isShopOpen)
            {
                shopCanvas.SetActive(false);
                isShopOpen = false;
            }
            else
            {
                shopCanvas.SetActive(true);
                isShopOpen = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            checker = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            checker = false;
            if (isShopOpen)
            {
                shopCanvas.SetActive(false);
                isShopOpen = false;
            }
        }
    }
}
