using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uiItem = new List<UIItem>();
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 25;

    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uiItem.Add(instance.GetComponentInChildren<UIItem>());

        }
    }

    public void UpdateSlots(int slot, Item item)
    {
        uiItem[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlots(uiItem.FindIndex(i => i.item == null), item);
    }

    public void RemoveItem(Item item)
    {
        UpdateSlots(uiItem.FindIndex(i => i.item == item), null);
    }
}
