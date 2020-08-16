using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TillControl : MonoBehaviour
{
    public List<Item> purchases;

    public int debate;

    public bool open;

    public GameObject shopUi, customer, player;

    private GameObject tillCam, mainCam, shopState;

    // Start is called before the first frame update
    void Start()
    {
        open = false;

        tillCam = GameObject.Find("Till_Cam");

        tillCam.SetActive(false);

        mainCam = GameObject.Find("Main_ThirdPersonCamera");

        shopState = GameObject.Find("ShopStateSave");
    }

    // Update is called once per frame
    void Update()
    {
        if(tillCam.activeSelf == true)
        {
            shopUi.SetActive(true);
        }
        else
        {
            shopUi.SetActive(false);
        }

        if(GameObject.FindGameObjectWithTag("Customer") == null && GameObject.FindGameObjectWithTag("Portal").GetComponent<CustomerSpawn>().CustomerCount == 0)
        {
            if(open != false)
            {
                open = false;
            }

        }

        if(open == false)
        {
            if(tillCam.activeSelf == true)
            {
                SwitchCam();

                //shopUi.SetActive(false);

                if(player != null)
                {
                    player.GetComponent<PlayerMovement>().cutscene = false;
                }


                //.FindGameObjectWithTag("Player").GetComponent<>().cutscene = false;
            }

            if(GameObject.Find("Town").GetComponent<DayNightCycle>().Day == false)
            {
                if(GameObject.FindGameObjectWithTag("Portal").GetComponent<CustomerSpawn>().CustomerCount == 0)
                {
                    GameObject.FindGameObjectWithTag("Portal").GetComponent<CustomerSpawn>().Selling = false;
                    GameObject.FindGameObjectWithTag("Portal").GetComponent<CustomerSpawn>().Reset();
                }
            }

        }
    }

    public void SwitchCam()
    {
        tillCam.SetActive(!tillCam.activeSelf);
        mainCam.SetActive(!mainCam.activeSelf);

        Cursor.visible = !Cursor.visible;

        if(Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        shopUi.SetActive(!shopUi.activeSelf);
        open = true;
    }

    public bool CheckSale(int want)
    {
        if(want <= debate)
        {
            List<GameObject> toRemove = new List<GameObject>();

            foreach(GameObject g in shopState.GetComponent<ProductChoices>().shelvesTaken)
            {
                foreach(Item i in purchases)
                {
                    if(g.GetComponent<ShelfHolder>().holding == i)
                    {
                        g.GetComponent<ShelfHolder>().holding = null;

                        toRemove.Add(g);
                    }
                }
              
            }
            if(toRemove.Count > 0)
            {
                foreach(GameObject g in toRemove)
                {
                    Destroy(g.GetComponent<ShelfHolder>().currentholding);
                    shopState.GetComponent<ProductChoices>().shelvesTaken.Remove(g);

                }
            }
            

            customer.GetComponent<CustomerController>().purchased = true;
            return true;
        }
        else
        {

            return false;
        }
    }

    public void shoppingList(List<Item> wants)
    {
        purchases.AddRange(wants);
    }
}
