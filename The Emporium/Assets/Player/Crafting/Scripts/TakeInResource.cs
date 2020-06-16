using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeInResource : MonoBehaviour
{
    public static TakeInResource instance;

    public List<Item> items = new List<Item>();

    public Sprite icon;

    private BackupInventory pInv;

    public Image[] dis = new Image[3];

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of crafting ingredients found");
            return;
        }
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //dis = transform.GetComponentsInChildren<Image>();

        pInv = GameObject.Find("Character").GetComponent<BackupInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        OrganiseImages();
    }

    public void CleanIngredients()
    {
        items = new List<Item>();
    }

    void OrganiseImages()
    {
        for (int i = 0; i < 3; i++)
        {
            if (items[i] != null)
            {
                dis[i].sprite = items[i].icon;
            }
            else
            {
                dis[i].sprite = icon;
            }
            
        }
        
    }

}
