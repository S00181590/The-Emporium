using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

     private float _currentHealth;
    public float PlayerHealth = 100;
    public Slider healthbar;

    private void Start()
    {
        _currentHealth = PlayerHealth;  
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        healthbar.value = _currentHealth;
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        if(_currentHealth >PlayerHealth)
        {
            PlayerHealth = _currentHealth;
        }
        healthbar.value = _currentHealth / PlayerHealth;
    }
}
