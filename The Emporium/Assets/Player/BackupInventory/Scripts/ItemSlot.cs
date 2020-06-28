using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    Item item;

    public Image icon;

    public Animator FemAnim;

    public GameObject itemName, craftUI;

    public DisplayItemDetails itemdetails;

    public Button removebutton;

    public void Start()
    {
        itemdetails = GameObject.Find("InventoryCanvas").GetComponent<DisplayItemDetails>();

        craftUI = GameObject.Find("ShopStateSave").GetComponent<ShopStatesReference>().craftingUI;

        //FemAnim = GameObject.Find("MC_FemaleFullRig").GetComponent<Animator>();
    }

    public void AddItem(Item newitem)
    {
        item = newitem;

        icon.sprite = item.icon;

        icon.enabled = true;

        removebutton.interactable = true;

        itemName.GetComponent<TMPro.TextMeshProUGUI>().text = item.title;

    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;

        icon.enabled = false;

        removebutton.interactable = false;

        itemName.GetComponent<TMPro.TextMeshProUGUI>().text = "";
    }

    public void OnRemoveButton()
    {
        Instantiate(item.physical, GameObject.Find("Character").transform.position, new Quaternion(0, Random.Range(1,360),0, 0));
        FemAnim.SetBool("UseInventory", true);
        BackupInventory.instance.Remove(item);
    }

    public void UseItem()
    {
        GameObject[] shelfs = GameObject.FindGameObjectsWithTag("ShelfUi"); 
        if(item != null)
        {
            if (craftUI.activeSelf == true)
            {
                if (GameObject.Find("CombinePanel").GetComponent<TakeInResource>().items.Count < 3)
                {
                    Debug.Log("Adding item " + item.title + " to crafting");
                    item.AddToCraft();
                    BackupInventory.instance.Remove(item);
                }

            }
            else
            {
                FemAnim.SetBool("UseInventory", true);
            }

            if (shelfs.Length > 0)
            {
                shelfs[0].GetComponent<ShelfUi>().AddItem(item);

                BackupInventory.instance.Remove(item);
            }
        }
    }

    public void updateDetails()
    {
        if (item != null)
        {
            if (itemdetails.gameObject.activeSelf == true)
            {
                itemdetails.toDisplay = item;
            }
        }
        else
        {
            itemdetails.toDisplay = null;
        }
    }



}
