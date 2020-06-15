using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingController : MonoBehaviour
{
    public GameObject materialpanel, ResultPanel, mainCamera, CraftCamera, inventoryUI;

    public RecipeBook recipes, knownRecipes;

    public DisplayItemDetails itemDetails;

    Recipe correctrecipe;

    private bool match;

    private Item result;

    public Sprite unknown;

    Sprite defImage;

    // Start is called before the first frame update
    void Start()
    {
        materialpanel = GameObject.Find("ShopStateSave").GetComponent<ShopStatesReference>().materialPanel;

        mainCamera = GameObject.Find("Main_ThirdPersonCamera");

        CraftCamera = GameObject.Find("Crafting_Cam");

        inventoryUI = GameObject.Find("InventoryCanvas");

        CraftCamera.SetActive(false);

        defImage = ResultPanel.GetComponent<Image>().sprite;

        itemDetails = GameObject.Find("InventoryCanvas").GetComponent<DisplayItemDetails>();
    }

    private void Update()
    {
        GetResult();
    }

    public void SetNewCamera()
    {
        mainCamera.SetActive(!mainCamera.activeSelf);

        CraftCamera.SetActive(!CraftCamera.activeSelf);
    }

    void GetResult()
    {
        
        string resID = "";

        resID = SortItemString();

        foreach(Recipe R in recipes.recipes)
        {
            if(R.RecipeCode == resID)
            {
                result = R.result;

                correctrecipe = R;
            }
        }

        foreach(Recipe k in knownRecipes.recipes)
        {
            if(k == correctrecipe)
            {
                match = true;
                break;
            }
            else
            {
                match = false;
            }
        }

        if(result != null)
        {
            if(match)
            {
                ResultPanel.GetComponent<Image>().sprite = result.icon;
            }
            else
            {
                ResultPanel.GetComponent<Image>().sprite = unknown;
            }

        }
        else
        {
            ResultPanel.GetComponent<Image>().sprite = defImage;
        }


    }

    public void hoverdetails()
    {
        if (result != null)
        {
            if(match)
            {
                if (itemDetails.gameObject.activeSelf == true)
                {
                    itemDetails.toDisplay = result;
                }
            }
            else
            {

            }
            
        }
        else
        {
            itemDetails.toDisplay = null;
        }
    }

    public void ConfirmCraft()
    {
        if (result != null)
        {


            BackupInventory.instance.inventory.Add(result);

            if (!knownRecipes.recipes.Contains(correctrecipe))
            {
                knownRecipes.recipes.Add(correctrecipe);
            }

            TakeInResource.instance.items.Clear();

            foreach (Image i in TakeInResource.instance.dis)
            {
                i.sprite = TakeInResource.instance.icon;
            }

            result = null;
        }

        BackupInventory.instance.changedCallback.Invoke();
    }

    string SortItemString()
    {
        TakeInResource ingredients = materialpanel.GetComponent<TakeInResource>();

        if (ingredients.items.Count == 1)
        {
            return ingredients.items[0].title;
        }
        else if (ingredients.items.Count == 2)
        {
            return ingredients.items[0].title + ingredients.items[1].title;
        }
        else if (ingredients.items.Count == 3)
        {
            return ingredients.items[0].title + ingredients.items[1].title + ingredients.items[2].title;
        }
        else
        {
            return "None";
        }
    }

    public void ClearCraft()
    {
        updatlist();
        
    }

    void updatlist()
    {
        if (TakeInResource.instance.items.Count > 0)
        {

            foreach (Item i in TakeInResource.instance.items)
            {
                BackupInventory.instance.inventory.Add(i);
            }

            TakeInResource.instance.items.Clear();

            foreach (Image i in TakeInResource.instance.dis)
            {
                i.sprite = TakeInResource.instance.icon;
            }
        }

        BackupInventory.instance.changedCallback.Invoke();
    }

    void Closing()
    {
        foreach (Item i in TakeInResource.instance.items)
        {
            BackupInventory.instance.inventory.Add(i);
        }

        TakeInResource.instance.items.Clear();

        foreach (Image i in TakeInResource.instance.dis)
        {
            i.sprite = TakeInResource.instance.icon;
        }

        SetNewCamera();

        GameObject.Find("CraftFrame").SetActive(false);

        inventoryUI.GetComponent<InventoryUI>().inventoryUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject.Find("Character").GetComponent<PlayerMovement>().cutscene = false;

        BackupInventory.instance.changedCallback.Invoke();

    }

    public void CancelCraft()
    {
        Closing();
    }
}
