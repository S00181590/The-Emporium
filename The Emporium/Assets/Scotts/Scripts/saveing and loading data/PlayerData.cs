using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerData
{
    //public Slider healthslider;
    // public float healthslidervalue;
    public float PlayersMana;
    public float MaxMana;
    public float  PlayersHealth;
    public float PlayersStamina;
    public float MaxStamina;
    public float MaxHealth;
    public decimal money;
    public float movementSpeed;
    public float[] position;
    //cons to get the infomation form Playerstas
    public PlayerData(PlayerStats player )
    {
        //healthslider= player.healthslider;
        // healthslidervalue = player.healthslidervalue;

        PlayersMana = player.PlayersMana;
        MaxMana = player.MaxMana;
        PlayersHealth = player.PlayersHealth;
        MaxHealth = player.MaxHealth;
        PlayersStamina = player.PlayersStamina;
        MaxStamina = player.MaxStamina;
        money = player.money;
        movementSpeed = player.movementSpeed;
        position = new float[3];//storeing the player pos useing an array to hold his x y and z cords
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}
