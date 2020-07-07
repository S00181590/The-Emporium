using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSellingUi : MonoBehaviour
{
    public TillControl till;

    public PlayerStats stats;

    public GameObject purchaseUI, salepriceInput,lessBtn,Morebtn,sellbtn, contentUI;

    private List<GameObject> purchases;

    public int saleprice;

    // Start is called before the first frame update
    void Start()
    {
        till = GameObject.FindGameObjectWithTag("Till").GetComponent<TillControl>();

        saleprice = 0;

        stats = GameObject.Find("Character").GetComponent<PlayerStats>();

        purchases = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(till.purchases != null)
        {
            if(purchases.Count < till.purchases.Count)
            {
                foreach(Item i in till.purchases)
                {
                    GameObject g = Instantiate(purchaseUI, contentUI.transform);

                    g.GetComponent<PurchaseItemSlot>().assignItem(i);

                    saleprice += i.Value;

                    purchases.Add(g);
                }
            }

        }

        salepriceInput.GetComponent<TMP_InputField>().text = saleprice.ToString();
    }

    public void enterAmount()
    {
        saleprice = int.Parse(salepriceInput.GetComponent<TMP_InputField>().text);
    }

    public void sell()
    {
        if (till.CheckSale(saleprice) == true)
        {
            till.purchases.Clear();

            foreach(GameObject g in purchases)
            {
                Destroy(g);
            }
            purchases.Clear();

            stats.money += saleprice;
        }
        else
        {

        }
    }


    public void AddToPrice()
    {
        saleprice++;
    }

    public void TakeFromPrice()
    {
        saleprice--;
    }
}
