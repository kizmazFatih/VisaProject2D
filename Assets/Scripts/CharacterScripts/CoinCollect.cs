
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{

    public static CoinCollect instance;
    public int coin = 0;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI coinTextOnShop;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        coinTextOnShop.text = coinText.text = coin.ToString();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coin += Random.Range(20, 50);
            Destroy(other.gameObject);
        }
    }
}
