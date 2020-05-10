using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txtName;
    public Image imgIcon;
    public int ItemId;

    public void SetItem(int itemID)
    {
        //finding the right item with the matching ID
        Item founditem = GameManager.Instance.AllItemsInTheGame.GetItem(itemID);

        //updateing the button with the data for that item 
        txtName.text = founditem.Name;
        imgIcon.sprite = founditem.Icon;
        imgIcon.color = founditem.Tint;

        ItemId = itemID;

    }
}
