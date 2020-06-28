using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShelfHolder : MonoBehaviour
{
    private Item holding;

    public bool opened;

    public int reference;

    public GameObject ShelfUI, ShopCanvas;

    public GameObject DisplayPoint, currentholding;

    // Start is called before the first frame update
    void Start()
    {
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(opened == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(GameObject.FindGameObjectsWithTag("ShelfUi").Length < 1)
                {
                    GameObject ui = Instantiate(ShelfUI, ShopCanvas.transform);

                    ui.GetComponent<ShelfUi>().current = holding;
                    ui.GetComponent<ShelfUi>().refid = reference;

                    GameObject.Find("InventoryCanvas").GetComponent<InventoryUI>().inventoryUI.SetActive(true);

                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;

                    Time.timeScale = 0.01f;
                    Time.fixedDeltaTime = 0.02f * Time.timeScale;

                    opened = false;
                }

            }
        }
    }

    public void clearItem()
    {
        holding = null;
    }

    public void AddingItem(Item item)
    {
        holding = item;

        currentholding = Instantiate(item.physical, DisplayPoint.gameObject.transform, false);

        currentholding.transform.localPosition = Vector3.zero;

        currentholding.GetComponent<Resource>().enabled = false;

    }
}
