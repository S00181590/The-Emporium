using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{


    public Slider healthslider;
   
    public void SetMaxHealth(int health)
    {
        healthslider.maxValue = health;
        healthslider.value = health;
    }

    public void SetHealth(int health)
    {
        healthslider.value = health;
    }
}
