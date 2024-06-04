using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private bool isShopOpen = false;


    private Canvas shopCanvas;

    private bool checker = false;
    void Start()
    {
        shopCanvas = GameObject.Find("ShopCanvas").GetComponent<Canvas>();
        shopCanvas.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && checker)
        {
            if (isShopOpen)
            {
                shopCanvas.enabled = false;
                isShopOpen = false;
            }
            else
            {
                shopCanvas.enabled = true;
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
                shopCanvas.enabled = false;
                isShopOpen = false;
            }
        }
    }
}
