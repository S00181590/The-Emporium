using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PurchaseItemSlot : MonoBehaviour
{
    private Item forPurchase;

    public GameObject icon, name, price;

    // Start is called before the first frame update
    void Start()
    {
        icon.GetComponent<Image>().sprite = forPurchase.icon;

        name.GetComponent<TextMeshProUGUI>().text = forPurchase.title;

        price.GetComponent<TextMeshProUGUI>().text = forPurchase.Value.ToString();
    }

    public void assignItem(Item item)
    {
        forPurchase = item;
    }

    // Update is called once per frame
    void Update()
    {
        //icon.GetComponent<Image>().sprite = forPurchase.icon;

        //name.GetComponent<TextMeshProUGUI>().text = forPurchase.title;

        //price.GetComponent<TextMeshProUGUI>().text = forPurchase.Value.ToString();
    }
}
