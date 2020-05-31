using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float PlayersHealth;
    public float MaxHealth;
    public Slider healthslider;


    public decimal money = 0;
    public int stamina = 100;
    public float movementSpeed = 5;



   private void Start()
    {
        
        PlayersHealth = MaxHealth;
        healthslider.value = GetCurrentHealth();
    }
   
   private void Update()
    {

       
        healthslider.value = GetCurrentHealth();
        takedamage();
     

        if (PlayersHealth <= 0)
        {
            Destroy(gameObject);
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

    public void SavePlayer()
    {
        SaveMangerSystem.SavePlayerData(this);

    }
   
    public void LoadPlayer()
    {
        PlayerData data = SaveMangerSystem.LoadingPlayer();
       // healthslider = data.healthslider;
        money = data.money;
        PlayersHealth = data.PlayersHealth;
        MaxHealth = data.MaxHealth;
        stamina = data.stamina;
        movementSpeed = data.movementSpeed;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

  
   
    void takedamage()
    {
        
        if (Input.GetKeyDown(KeyCode.R))
        { if (PlayersHealth > 0) PlayersHealth = PlayersHealth - 20; }


        if (Input.GetKeyDown(KeyCode.T))
        { if (PlayersHealth > 0) PlayersHealth = PlayersHealth + 20; }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Enemey")
        {
            PlayersHealth -= 10;
        }
    }
}

