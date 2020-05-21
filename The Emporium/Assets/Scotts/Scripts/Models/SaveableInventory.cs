//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;


////allowing a inventory to be savaed to a json file
////onlys saves the ids of each item
////the gamemanger has access to every item in the game
//[Serializable]
//public class SaveableInventory 
//{
//    public List<int> Items = new List<int>();
//   public void AddItem(int itemID)
//    {
//        Items.Add(itemID);
//    }

//    public void AddItem(string name)
//    {
//        Item foundItem = GameManager.Instance.AllItemsInTheGame.GetItem(name);
//        if (foundItem != null)
//            AddItem(foundItem);
//    }

//    public void AddItem(Item item)
//    {
//        AddItem(item.ID);
//    }

//    //saveing the current instance of the class to json
//     public void Save(string filename)
//    {
//        string json = JsonUtility.ToJson(this, true);
//        File.WriteAllText(Application.persistentDataPath + "/" + filename + ".json",json);
//    }

//    public void Load(string filename)
//    {
//        if(File.Exists(Application.persistentDataPath + "/" + filename +".json"))
//        {
//            string json = File.ReadAllText(Application.persistentDataPath + "/" + filename + ".json");
//            Items = JsonUtility.FromJson<SaveableInventory>(json).Items;
//        }                                                                                                                                                                                                                                            
//    }
//}
