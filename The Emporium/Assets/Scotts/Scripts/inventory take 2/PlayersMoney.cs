using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Players Money ", menuName = "Inventory System/Money")]
public class PlayersMoney : ItemObject
{
    public decimal Money;

    public void Awake()
    {
        type = ItemType.Money;
    }
}
