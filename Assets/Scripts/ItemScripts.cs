using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScripts : MonoBehaviour
{
    public Button shieldButton;
    public void HealthPoison()
    {

    }

    public void Shield()
    {


        if (!CharacterHealth.instance.isThereShield)
        {
            shieldButton.interactable = false;
            CharacterHealth.instance.isThereShield = true;

        }

    }

    public void FirePunchSkill()
    {

    }

    public void CloseTab(){
        this.gameObject.SetActive(false);
    }
}
