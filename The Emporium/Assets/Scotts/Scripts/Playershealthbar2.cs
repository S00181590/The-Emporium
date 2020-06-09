//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class Playershealthbar2 : MonoBehaviour
//{
//    public Slider healthslider;
//    public float PlayersHealth;
//    public float MaxHealth;
//    private void Start()
//    {
//        healthslider.value = GetCurrentHealth(); healthslider.value = GetCurrentHealth();

//    }
//    private void Update()
//    {
//        healthslider.value = GetCurrentHealth();
//    }

//    float GetCurrentHealth()
//    {
//        return PlayersHealth / MaxHealth;
//    }


//    void takedamage()
//    {

//        if (Input.GetKeyDown(KeyCode.R))
//        { if (PlayersHealth > 0) PlayersHealth = PlayersHealth - 20; }


//        if (Input.GetKeyDown(KeyCode.T))
//        { if (PlayersHealth > 0) PlayersHealth = PlayersHealth + 20; }

//    }

//    public void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Enemey")
//        {
//            PlayersHealth -= 10;
//        }
//    }
//}
