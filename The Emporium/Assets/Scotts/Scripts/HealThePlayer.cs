using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealThePlayer : MonoBehaviour
{

    public GameObject  Player;
    public int cost;
    PlayerStats playerStats;
    public bool playerinrange;
    public GameObject openshopInventory;
    public Item hpotion;
    //BackupInventory backupInventory;
    // Start is GameObjectcalled before the first frame update
    void Start()
    {
        Player = GameObject.Find("Character");

        playerStats = Player.GetComponent<PlayerStats>(); /*FindObjectOfType<PlayerStats>()*/;
        //backupInventory = FindObjectOfType<BackupInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && playerinrange ==true )
        {
            openshopInventory.SetActive(!openshopInventory.activeSelf);

            if (Cursor.lockState != CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            //openplayersInventory.SetActive(false);
        }
    }

    public  void  HealPlayerStats()
    {
        if(playerStats.PlayersHealth < playerStats.MaxHealth || playerStats.PlayersMana < playerStats.MaxMana || 
           playerStats.PlayersStamina < playerStats.MaxStamina)
        {
            if (playerStats.money >= 50)
            {

                 playerStats.PlayersHealth = playerStats.MaxHealth;
                 playerStats.PlayersMana = playerStats.MaxMana;
                 playerStats.PlayersStamina = playerStats.MaxStamina;
                 playerStats.money -= 50;
                Debug.Log("Playersststrestored");
            }
        }

    }


    public void IncreasPlayersHealth()
    {
        //if (playerStats.money >= 1000)
       // {
            
         playerStats.MaxHealth += 20;
        playerStats.CheckMana();
        playerStats.GetCurrentStamina();
        // playerStats.money -= 1000;
            Debug.Log("playershealthincreased");
      //  }
    }

    public void IncreasPlayersMana()
    {
       // if (playerStats.money >= 1000)
       // {

            playerStats.MaxMana += 20;
        playerStats.CheckMana();
            //playerStats.money -= 1000;
            Debug.Log("playersmanaincreased");
       // }
    }
    public void IncreasPlayersStamina()
    {
       // if (playerStats.money >= 1000)
       // {

            playerStats.MaxStamina += 20;
            playerStats.money -= 1000;
            Debug.Log("playersstaminaincreased");
       // }
    }
    public void CloseWindow()
    {
        openshopInventory.SetActive(false);

    }
    public void BuyaDeed()
    {
       // if (playerStats.money >= 10000)
       // {


            //playerStats.money -= 10000;
            Debug.Log("deedbrough");
        //}
    }

    public void BuyHealthPotion()
    {
        if (playerStats.money >= 0)
        {
            if (BackupInventory.instance.inventory.Count <= BackupInventory.instance.possessions)
            {
                BackupInventory.instance.inventory.Add(hpotion);
                playerStats.money -= 15;

            }
        }
        Debug.Log("Healthpotionbrought");

        BackupInventory.instance.changedCallback();
        
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.tag.Equals("Player"))
    //    {
    //        playerinrange = true;
    //    }
    //    else
    //    {
    //        playerinrange = false;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerinrange = false;
    //        openshopInventory.SetActive(false);
    //    }
    //}
}
