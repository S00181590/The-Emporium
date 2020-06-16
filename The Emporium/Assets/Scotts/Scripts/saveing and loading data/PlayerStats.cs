using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public float PlayersHealth;
    public float MaxHealth;
    public float PlayersMana;
    public float  MaxMana;
    public float PlayersStamina;
    public float MaxStamina;
    public Slider ManaSlider;
    public Slider healthslider;
    public Slider StaminaSlider;
    //  public float  Playersstamina;
    // public float healthslidervalue;
    GameObject objecht;
    private bool collided;



    public decimal money = 0;
    public float movementSpeed = 5;

    //public void OnTriggerEnter(Collider other)
    //{
    //    collided = true;
    //}
    //public void OnTriggerExit(Collider other)
    //{
    //    collided = false;
    //}
    

    private void Start()
    {
        PlayersStamina = MaxStamina;
        PlayersMana = MaxMana;
        PlayersHealth = MaxHealth;

        healthslider.value = GetCurrentStamina();
        healthslider.value = GetCurrentMana();
        healthslider.value = GetCurrentHealth();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EnemyArrow"))
        {
            PlayersHealth -= 10;
            
        }
    }
    private void Update()
    {
        StaminaSlider.value = GetCurrentStamina();
        UseStaminaTest();
        ManaSlider.value = GetCurrentMana();
        UseManaTest();
        healthslider.value = GetCurrentHealth();
     
        if (PlayersHealth <= 0)
        {
            Destroy(gameObject);
        }

        if (PlayersHealth >= MaxHealth)
        {
            PlayersHealth = MaxHealth;
        }

        if(PlayersMana >= MaxMana)
        {
            PlayersMana = MaxMana;
        }
    }

    float GetCurrentStamina()
    {
        return PlayersStamina / MaxStamina;
    }
    float GetCurrentMana()
    {
        return PlayersMana /MaxMana;
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
        PlayersMana = data.PlayersMana;
        MaxMana = data.MaxMana;
        PlayersHealth = data.PlayersHealth;
        MaxHealth = data.MaxHealth;
        PlayersStamina = data.PlayersStamina;
        MaxStamina = data.MaxStamina;
        money = data.money;
        movementSpeed = data.movementSpeed;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    void UseStaminaTest()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (PlayersStamina > 0) PlayersStamina = PlayersStamina - 20;
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            if (PlayersStamina >= 0) PlayersStamina = PlayersStamina + 20;
        }

    }
    void UseManaTest()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (PlayersMana > 0) PlayersMana = PlayersMana - 20;
        }


        if (Input.GetKeyDown(KeyCode.U))
        {
            if (PlayersMana >= 0) PlayersMana = PlayersMana + 20;
        }

    }
    void takedamage(float amount)
    {

        PlayersHealth -= amount;
        if(PlayersHealth <=0)
        {
            Destroy(gameObject);
        }

            //if (Input.GetKeyDown(KeyCode.R))
            //{ if (PlayersHealth > 0) PlayersHealth = PlayersHealth - 20; }


            //if (Input.GetKeyDown(KeyCode.T))
            //{ if (PlayersHealth >= 0) PlayersHealth = PlayersHealth + 20; }
    }
   


}

