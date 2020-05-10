using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public decimal money = 0;
    public int health = 100;
    public int stamina = 100;
    public float movementSpeed = 5;


    public void SavePlayer()
    {
        SaveMangerSystem.SavePlayerData(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveMangerSystem.LoadingPlayer();

        money = data.money;
        health = data.health;
        stamina = data.stamina;
        movementSpeed = data.movementSpeed;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }
}
