using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    BackupInventory inventory;

    public bool crafting, invent;

    public GameObject inventoryUI, itemDisplay;

    public GameObject itemslotParent;

    public GameObject Inventorycam, mainCam;

    public Animator FemChar, maleChar;

    public GameObject Player;

    float normal;

    ItemSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        normal = Time.timeScale;
        inventory = BackupInventory.instance;
        inventory.changedCallback += UpdateUI;

        invent = false;

        crafting = false;

        Player = GameObject.Find("Character");

        mainCam = GameObject.Find("Main_ThirdPersonCamera");

        Inventorycam = GameObject.Find("Inventory_Cam");

        //itemDisplay = GameObject.Find("Item_DetailPanel");

        Inventorycam.SetActive(false);

        //inventoryUI = GameObject.Find("PlayerInventory");

        //itemslotParent = GameObject.Find("Inventory");

        slots = itemslotParent.GetComponentsInChildren<ItemSlot>();

        if(FemChar.gameObject.activeSelf)
        {

        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!crafting)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {

                if (Cursor.lockState == CursorLockMode.Locked)
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
                //itemDisplay.SetActive(!itemDisplay.activeSelf);

                Inventorycam.SetActive(!Inventorycam.activeSelf);

                Player.GetComponent<PlayerMovement>().cutscene = Player.GetComponent<PlayerMovement>().cutscene;

                invent = !invent;

                mainCam.SetActive(!mainCam.activeSelf);

            }
        }
        else
        {
            //if(Input.GetKeyDown(KeyCode.E))
            //{
            //    uiSwitch();
            //}

        }

        if (FemChar.gameObject.activeSelf)
        {
            FemChar.SetBool("InInventory", invent);
        }
        else
        {
            maleChar.SetBool("InInventory", invent);
        }

        
    }

    public void uiSwitch()
    {
        if (Cursor.lockState == CursorLockMode.Locked)
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
        //itemDisplay.SetActive(!itemDisplay.activeSelf);

        //Inventorycam.SetActive(!Inventorycam.activeSelf);

        Player.GetComponent<PlayerMovement>().cutscene = Player.GetComponent<PlayerMovement>().cutscene;
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
