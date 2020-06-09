using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingController : MonoBehaviour
{
    public GameObject materialpanel, ResultPanel;

    private bool match;

    private Item result;

    // Start is called before the first frame update
    void Start()
    {
        materialpanel = GameObject.Find("CombinePanel");
    }

    private void Update()
    {
        GetResult();
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

        BackupInventory.instance.changedCallback.Invoke();
    }

    void Closing()
    {
        foreach (Item i in TakeInResource.instance.items)
        {
            BackupInventory.instance.inventory.Add(i);
        }

        TakeInResource.instance.items.Clear();

        GameObject.Find("CraftFrame").SetActive(false);

        GameObject.Find("Character").GetComponent<PlayerMovement>().cutscene = false;

        BackupInventory.instance.changedCallback.Invoke();

    }

    public void CancelCraft()
    {
        Closing();
    }
}
