using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Potion", menuName = "Inventory/Potion")]
public class Potion : Item
{
    //public int id = 0;
    //public string title = "New Item";
    //public string descrption = "This is an item";
    //public Sprite icon = null;
    //public bool isDefaultItem = false;
    //Dictionary<string, int> stats = new Dictionary<string, int>();

    public override void Use()
    {
        PlayerStats player = GameObject.Find("Character").GetComponent<PlayerStats>();
        
        foreach(string s in stats.Keys)
        {
            if(s == "Health" || s == "health")
            {
                player.PlayersHealth += stats[s];
            }

        }
    }
}
