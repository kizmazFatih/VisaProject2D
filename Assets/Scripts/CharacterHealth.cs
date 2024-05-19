using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public static CharacterHealth instance;

    public ItemScripts itemScript;
    public float health = 100;
    public float shieldHealth = 50;

    public bool isThereShield = false;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        if (isThereShield)
        {
            if (damageAmount <= shieldHealth)
            {
                shieldHealth -= damageAmount;
            }
            else
            {
                float residualDamage = Mathf.Abs(shieldHealth - damageAmount);
                shieldHealth = 0;
                health -= residualDamage;
            }
        }
        else
        {
            health -= damageAmount;
        }


        if (shieldHealth <= 0)
        {
            isThereShield = false;
            itemScript.shieldButton.interactable = true;
        }
    }


}
