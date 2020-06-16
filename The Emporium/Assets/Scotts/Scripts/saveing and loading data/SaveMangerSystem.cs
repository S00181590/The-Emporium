using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static  class SaveMangerSystem //makeing it static because we dont want to create more the one save manager
{
    public static void SavePlayerData(PlayerStats player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/player.saves"; //unity handles the save location by useing Application.persistentDataPath 
        FileStream stream = new FileStream(savePath, FileMode.Create);

        PlayerData data = new PlayerData(player);//useing the constructor created in the playerdata can add more stats by updateing the cons and the class
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadingPlayer()//not static as we want it to return 
    {
        string savePath = Application.persistentDataPath + "/player.saves";
        if(File.Exists(savePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(savePath, FileMode.Open);//useing the open this time to read form the created save file
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found" + savePath);
            return null;
        }
    }

}
