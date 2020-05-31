using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Item>playerItems = new List<Item>();//list of items 
    public ItemDataBase ItemDataBase;
    public UIInventory inventoryUI;


    private void Start()
    {
        GiveItem(0);
        //GiveItem(1);
        //RemoveItem(2);
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.gameObject.SetActive(!inventoryUI.gameObject.activeSelf);
        }
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = ItemDataBase.GetItem(id);
        playerItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("added item:" + itemToAdd.title);
    }
    public Item checkForItem(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id )
    {
        Item ItemToRemove = checkForItem(id);
        if(ItemToRemove != null)
        {
            playerItems.Remove(ItemToRemove);
            inventoryUI.RemoveItem(ItemToRemove);
            Debug.Log("Item removed:" + ItemToRemove.title);
        }
    }
}