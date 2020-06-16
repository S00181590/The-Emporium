using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playercurrentstats1 : MonoBehaviour
{


    public float PlayersHealth;
    public float MaxHealth;

   
    public Slider healthslider;

    private void Start()
    {
        PlayersHealth = MaxHealth;
        healthslider.value = GetCurrentHealth();
    }

    private void Update()
    {
        healthslider.value = GetCurrentHealth();

      

        if (PlayersHealth <= 0)
        {
          //  Destroy(gameObject);
        }

        if (PlayersHealth >= MaxHealth)
        {
            PlayersHealth = MaxHealth;
        }
    }

    float GetCurrentHealth()
    {
        return PlayersHealth / MaxHealth;
    }

}