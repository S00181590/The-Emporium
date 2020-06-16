using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public List<Item> items = new List<Item>();


    private void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem (string itemName)
    {
        return items.Find(item => item.title == item.name);
    }

    void BuildDatabase()
    {
        //items = new List<Item>() { 
        //    new Item(0, "Rusty Sword", "An old sword.",
        //    new Dictionary<string, int>
        //    {
        //        {"Power",5},
        //        {"Defence",5 }
        //    }),
        //      new Item(1, "old shield", "An old shield.",
        //    new Dictionary<string, int>
        //    {
        //        {"Power",0},
        //        {"Defence",10 }
        //    }),
        //        new Item(2, "Old Pickaxe", "An old Pickaxe can be used to mine ores .",
        //    new Dictionary<string, int>
        //    {
        //        {"Power",5},
        //        {"Mining",100 }
        //    }),
        //    new Item(3, "Rock", "It's a rock...",
        //    new Dictionary<string, int>
        //    {
                
        //    })
        //    };
    }
}
