//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class InventorySlotController : MonoBehaviour
//{
//    public Item item;//creating a refernce

//    private void Start()
//    {
//        UpdateInventoryInfo();
//    }

//    public void use()
//    {
//        if (item)
//        {
//            item.Use();
//        }
//    }

//    public void UpdateInventoryInfo()
//    {
//        Text displayText = transform.Find("Text").GetComponent<Text>();
//        Image displayImage = transform.Find("Image").GetComponent<Image>();

//        if (item)
//        {
//            displayText.text = item.itemName;
//            displayImage.sprite = item.itemIcon;
//            displayImage.color = Color.white;
//        }
//        else
//        {
//            displayText.text = "";
//            displayImage.sprite = null;
//            displayImage.color = Color.clear;

//        }


//    }

//}
