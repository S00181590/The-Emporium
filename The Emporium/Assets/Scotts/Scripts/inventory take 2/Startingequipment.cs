using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Starting Equpiment",menuName ="Inventory System/starting equipment/defaault")]
public class Startingequipment : ItemObject
{
    public void Awake()
    { 
        //dont have to maulally set item type
        type = ItemType.StartingEquipment;
    }

}

