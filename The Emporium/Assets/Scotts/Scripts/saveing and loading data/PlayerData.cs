using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerData
{
    public decimal money;
    public int health;
    public int stamina;
    public float movementSpeed;
    public float[] position;

    //cons to get the infomation form Playerstas
    public PlayerData(PlayerStats player )
    {
        money = player.money;
        health = player.health;
        stamina = player.stamina;
        movementSpeed = player.movementSpeed;
        position = new float[3];//storeing the player pos useing an array to hold his x y and z cords
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

    }

}
