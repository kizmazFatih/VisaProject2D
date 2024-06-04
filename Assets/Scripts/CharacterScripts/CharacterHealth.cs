using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterHealth : MonoBehaviour
{
    public static CharacterHealth instance;

    [Header("UI Elements")]
    public RectTransform healthBar;
    public RectTransform shieldBar;

    public ItemScripts itemScript;
    public float health = 100;
    public float shieldHealth;

    public bool isThereShield = true;

    private Animator animator;

    public bool death = false;


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

    void Start()
    {
        animator = GetComponent<Animator>();
        shieldHealth=50;
        
    }

    void Update()
    {
        UpdateUI();
    }

    public void TakeDamage(float damageAmount)
    {

        animator.SetTrigger("Damaged");
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

        if (health <= 0)
        {
            health = 0;
            death = true;
            animator.SetBool("Death", true);
        }
        else if (health < 100)
        {
            itemScript.healthPoisonButton.interactable = true;
        }

    }


    void UpdateUI()
    {
        healthBar.localScale = new Vector3(health / 100, 1, 1);
        shieldBar.localScale = new Vector3(shieldHealth / 50, 1, 1);
    }

}
