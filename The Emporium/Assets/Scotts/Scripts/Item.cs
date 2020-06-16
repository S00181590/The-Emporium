using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    
    public int  id = 0;
    public string title = "New Item";
    public string descrption = "This is an item";
    public GameObject physical;
    public Sprite icon = null;
    public bool isDefaultItem = false;
    public Dictionary<string, int> stats = new Dictionary<string, int>();

    public virtual void Use()
    {
         
    }

    public virtual void AddToCraft()
    {
        Item i = this;

        GameObject.Find("CombinePanel").GetComponent<TakeInResource>().items.Add(i);
    }

   // public Item (int id,string title,string descrption ,
   //     Dictionary<string,int> stats)
   // {
   //     this.id = id;
   //     this.title = title;
   //     this.descrption = descrption;
   //     this.icon = Resources.Load<Sprite>("Assets/Items/" + title);
   //     this.stats = stats;

   // }
   //public Item (Item item)
   // {
   //     this.id = item.id;
   //     this.title = item.title;
   //     this.descrption = item.descrption;
   //     this.icon = Resources.Load<Sprite>("Assets/Items/" + item.title);
   //     this.stats = item.stats;
   // }
   
}
