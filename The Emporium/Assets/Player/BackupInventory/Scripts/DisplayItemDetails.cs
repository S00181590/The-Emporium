using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayItemDetails : MonoBehaviour
{
    public Item toDisplay;

    public bool isActive;

    public GameObject detailItemUI;

    public TextMeshProUGUI Title, Description;

    public Image Icon;

    // Start is called before the first frame update
    void Start()
    {
        //isActive = false;

        toDisplay = null;

        //detailItemUI = GameObject.Find("Item_DetailPanel");

        //detailItemUI.SetActive(isActive);

        //Title = GameObject.Find("ItemTitle").GetComponent<TextMeshProUGUI>();

        //Icon = GameObject.Find("ItemIcon").GetComponent<Image>();

        //Description = GameObject.Find("ItemDetails").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(toDisplay != null)
        {
            Title.text = toDisplay.title;
            Icon.sprite = toDisplay.icon;
            Icon.enabled = true;
            Description.text = toDisplay.descrption;
        }
        else
        {
            Title.text = "";
            Icon.sprite = null;
            Icon.enabled = false;
            Description.text = "";
        }
    }
}
