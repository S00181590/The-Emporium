using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RandomItemdrops
{
    [SerializeField]
    private Item itemdrop;

    [SerializeField]
    private float dropchance;

    public Item enemeyItem
    {
        get
        {
            return itemdrop;
        }
    }

    public float DropChance
    {
        get
        {
            return dropchance;
        }
    }


}


