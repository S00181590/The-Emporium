using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupInventory : MonoBehaviour
{
    public static BackupInventory instance;
    public List<Item> inventory = new List<Item>();
    int possessions = 20;

    public delegate void OnItemChanged();
    public OnItemChanged changedCallback;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of backup inventory found");
            return;
        }
        instance = this;
    }


    public bool AddItem(Item item)
    {
        if(!item.isDefaultItem)
        {
            if(inventory.Count >= possessions)
            {
                Debug.Log("Not enough Room");
                return false;
            }

            inventory.Add(item);

            if(changedCallback != null)
            {
                changedCallback.Invoke();
            }

        }

        return true;
    }

    public void Remove(Item item)
    {
        inventory.Remove(item);

        if (changedCallback != null)
        {
            changedCallback.Invoke();
        }
    }

}
