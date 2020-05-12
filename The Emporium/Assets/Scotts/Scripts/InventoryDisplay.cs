using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public Transform Content;
    public GameObject ItemButtonPrefab;

    public void SetInventory(List<int> items)
    {
        GameObject button;
        foreach (int id in items)
        {
            button = Instantiate(ItemButtonPrefab, Content);
            button.GetComponent<ItemButton>().SetItem(id);
        }
    }
}
