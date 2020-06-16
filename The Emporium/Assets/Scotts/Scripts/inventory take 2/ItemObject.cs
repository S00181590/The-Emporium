using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Potion,
    Equipment,
    Money,
    StartingEquipment,
    Resource
}
public abstract class ItemObject :ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea (20,20)]
    public string descrption;

}