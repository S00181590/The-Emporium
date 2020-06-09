using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    Item item;

    public Image icon;

    public Button removebutton;

    public void AddItem(Item newitem)
    {
        item = newitem;

        icon.sprite = item.icon;

        icon.enabled = true;

        removebutton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;

        icon.enabled = false;

        removebutton.interactable = false;
    }

    public void OnRemoveButton()
    {
        BackupInventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if(GameObject.Find("CraftFrame").activeSelf == true)
            {
                if(GameObject.Find("CombinePanel").GetComponent<TakeInResource>().items.Count < 3)
                {
                    Debug.Log("Adding item "+item.title+" to crafting");
                    item.AddToCraft();
                    BackupInventory.instance.Remove(item);
                }

            }

            item.Use();
        }
    }


}
