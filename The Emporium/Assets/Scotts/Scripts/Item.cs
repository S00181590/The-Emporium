using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    
    public int  id;
    public string title;
    public string descrption;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();


    public Item (int id,string title,string descrption ,
        Dictionary<string,int> stats)
    {
        this.id = id;
        this.title = title;
        this.descrption = descrption;
        this.icon = Resources.Load<Sprite>("Assets/Items/" + title);
        this.stats = stats;

    }
   public Item (Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.descrption = item.descrption;
        this.icon = Resources.Load<Sprite>("Assets/Items/" + item.title);
        this.stats = item.stats;
    }
   
}
