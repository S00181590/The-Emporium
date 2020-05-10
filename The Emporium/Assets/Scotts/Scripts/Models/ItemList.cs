using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//game manager holds a refence to this class
[Serializable]
[CreateAssetMenu(fileName ="ItemList",menuName ="Items/List")]
public class ItemList : ScriptableObject
{
    public List<Item> Items = new List<Item>();

    //uses the ID of an item to return an instance of the item
    public Item GetItem(int itemID)
    {
        return Items.Find(item => item.ID == itemID);
    }

    //usesing the name of an item to return an instance of the item 
    public Item GetItem(string itemName)
    {
        return Items.Find(Item => Item.Name == itemName);
    }
}
