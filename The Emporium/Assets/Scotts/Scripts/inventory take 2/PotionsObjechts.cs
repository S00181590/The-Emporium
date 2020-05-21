using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = " Potion", menuName = "Inventory System/potion")]
public class PotionsObjechts : ItemObject
{
    public int restorehealthvalue;

    public void Awake()
    {
        type = ItemType.Potion;
    }
}
