using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShelfUi : MonoBehaviour
{
    public Image itemImage;

    public TextMeshProUGUI itemName;

    GameObject itemObject, shelf, itempoint;

    private DisplayItemDetails itemdetails;

    public Item current;

    public int refid;

    // Start is called before the first frame update
    void Start()
    {
        itemdetails = GameObject.Find("InventoryCanvas").GetComponent<DisplayItemDetails>();

        GameObject[] shelfs = GameObject.FindGameObjectsWithTag("Shelf");

        if (shelfs.Length > 0)
        {

            foreach (GameObject g in shelfs)
            {
                if(g.GetComponent<ShelfHolder>().reference == refid)
                {
                    shelf = g;
                    itempoint = g.GetComponent<ShelfHolder>().DisplayPoint;
                }
            }
        }

        if (current == null)
        {
            itemObject = null;
        }
        else
        {
            itemObject = current.physical;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (current != null)
        {
            itemImage.sprite = current.icon;
            itemName.text = current.title;
            itemObject = current.physical;
        }
       
    }

    public void AddItem(Item item)
    {
        if(current == null)
        {
            current = item;

            itemImage.sprite = current.icon;
            itemName.text = current.title;
            itemObject = current.physical;

            shelf.GetComponent<ShelfHolder>().AddingItem(current);
           
        }
    }

    public void emptySlot()
    {
        BackupInventory.instance.inventory.Add(current);

        current = null;

        Destroy(shelf.GetComponent<ShelfHolder>().currentholding);

        shelf.GetComponent<ShelfHolder>().clearItem();

        itemObject = null;
        itemImage.sprite = null;
        itemName.text = "Empty";

        BackupInventory.instance.changedCallback();
    }

    public void hoverInfo()
    {
        if (current != null)
        {
            if (itemdetails.gameObject.activeSelf == true)
            {
                itemdetails.toDisplay = current;
            }

        }
        else
        {
            itemdetails.toDisplay = null;
        }
    }

    public void closeButton()
    {
        GameObject.Find("InventoryCanvas").GetComponent<InventoryUI>().inventoryUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        Destroy(gameObject);
    }
}
