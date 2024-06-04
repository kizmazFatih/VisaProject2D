using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScripts : MonoBehaviour
{
    public Button shieldButton;
    public Button firePunchButton;
    public Button healthPoisonButton;
    public void HealthPoison()
    {
        if (CoinCollect.instance.coin >= 150)
        {
            healthPoisonButton.interactable = false;
            CharacterHealth.instance.health = 100;
            CoinCollect.instance.coin -= 150;
        }
    }

    public void Shield()
    {


        if (!CharacterHealth.instance.isThereShield && CoinCollect.instance.coin >= 200)
        {
            shieldButton.interactable = false;
            CharacterHealth.instance.isThereShield = true;
            CharacterHealth.instance.shieldHealth = 50;
            CoinCollect.instance.coin -= 200;

        }

    }

    public void FirePunchSkill()
    {
        if (CoinCollect.instance.coin >= 400)
        {
            firePunchButton.interactable = false;
            Movement.instance.firePunchActive = true;
            CoinCollect.instance.coin -= 400;
        }
    }

    public void CloseTab()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
    }
}
