using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemeyHealth : MonoBehaviour
{
    public float health;
    public float MaxHealth;

    public GameObject healthBarUI;
    public Slider healthslider;

    private void Start()
    {
        health = MaxHealth;
        healthslider.value = GetCurrentHealth();
    }

    private void Update()
    {
       // TakeDamage(10);
         healthslider.value= GetCurrentHealth();
      
        if(health <MaxHealth)//turning on the health bar when enemy takes damage 
        {
            healthBarUI.SetActive(true);
        }

        if(health <=0)
        {
            Destroy(gameObject);
        }

        if(health >= MaxHealth)
        {
            health = MaxHealth;
        }
    }

    float GetCurrentHealth()
    {
        
       return health /MaxHealth;
    }
    public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Arrow"))
        {
            health -= 10;
        }
    }
}
