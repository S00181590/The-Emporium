using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingController : MonoBehaviour
{
    public GameObject materialpanel, ResultPanel, mainCamera, CraftCamera;

    private bool match;

    private Item result;

    // Start is called before the first frame update
    void Start()
    {
        materialpanel = GameObject.Find("CombinePanel");

        mainCamera = GameObject.Find("Main_ThirdPersonCamera");

        CraftCamera = GameObject.Find("Crafting_Cam");

        CraftCamera.SetActive(false);
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



        if(match)
        {

        }
        else
        {
            
        }
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
        foreach(Item i in TakeInResource.instance.items)
        {
            BackupInventory.instance.inventory.Add(i);
        }

        TakeInResource.instance.items.Clear();

        foreach(Image i in TakeInResource.instance.dis)
        {
            i.sprite = TakeInResource.instance.icon;
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

        GameObject.Find("Character").GetComponent<PlayerMovement>().cutscene = false;

        BackupInventory.instance.changedCallback.Invoke();

    }

    public void CancelCraft()
    {
        Closing();
    }
}
