using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItem = new List<UIItem>();
    public GameObject slotPrefab;
    GameObject instance;
    public Transform slotPanel;
    public int numberOfSlots = 25;

    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            //if(uiItem[i] != null)
            //{

            //    slotPrefab.GetComponentInChildren<Image>().sprite = Resources.Load("ItemSprites/Rock") as Sprite;
                
                instance = Instantiate(slotPrefab);
                instance.transform.SetParent(slotPanel);
                uiItem.Add(instance.GetComponentInChildren<UIItem>());
            //}
            //else
            //{
            //    instance = Instantiate(slotPrefab);
            //    instance.transform.SetParent(slotPanel);
            //    uiItem.Add(instance.GetComponentInChildren<UIItem>());
            //}
            

        }
    }

    public void UpdateSlots(int slot, Item item)
    {
        uiItem[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlots(uiItem.FindIndex(i => i.item /*== null*/), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlots(uiItem.FindIndex(i => i.item == item), null);
    }
}
