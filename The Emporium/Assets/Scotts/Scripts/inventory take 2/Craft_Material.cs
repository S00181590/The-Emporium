using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crafting_Material", menuName = "Inventory System/ Materials")]
public class Craft_Material : ItemObject
{
    public void Awake()
    {
        type = ItemType.Resource;
    }
}
