using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory ", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public List<InventorySlots> Container = new List<InventorySlots>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item  == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if(!hasItem)
        {
            Container.Add(new InventorySlots(_item, _amount));
        }
    }
}

[System.Serializable]
public class InventorySlots
{
    public ItemObject item;
    public int amount;
    public InventorySlots(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }

    public void AddAmount (int value)
    {
        amount += value;
    }
}
