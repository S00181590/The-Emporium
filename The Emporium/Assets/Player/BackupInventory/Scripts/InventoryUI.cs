using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    BackupInventory inventory;

    public GameObject inventoryUI;

    public GameObject itemslotParent;

    float normal;

    ItemSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        normal = Time.timeScale;
        inventory = BackupInventory.instance;
        inventory.changedCallback += UpdateUI;

        //inventoryUI = GameObject.Find("PlayerInventory");

        //itemslotParent = GameObject.Find("Inventory");

        slots = itemslotParent.GetComponentsInChildren<ItemSlot>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {

            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                //Time.timeScale = 0.02f;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                //Time.timeScale = normal;
            }
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = !Cursor.visible;
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

    }

    void UpdateUI()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            if(i < inventory.inventory.Count)
            {
                slots[i].AddItem(inventory.inventory[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
