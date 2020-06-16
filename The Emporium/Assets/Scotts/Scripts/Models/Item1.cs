using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this is the base class for every item in the game 
//this included items that only exist in and inventory and items
//that can be found or dropped in the world
[Serializable]
public class Item1
{
    public int ID;//must be unque for each item 
    public string Name;
    public string Description;
    public float Value;
    public Color Tint = Color.white;//make sure the alpha is set to white
    public Sprite Icon;
    
    //this is used so the item can be soawned in the game as a game objecht 
    public GameObject Prefab;
}
