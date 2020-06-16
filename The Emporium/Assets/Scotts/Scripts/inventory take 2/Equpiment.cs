using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " Equpiment", menuName = "Inventory System/ equipment")]
public class Equpiment : ItemObject
{
    public float AttackBouns;
    public float DefenceBounus;
    public float StaminBouns;
    public float MovementBouns;

    public void Awake()
    {
        type = ItemType.Equipment;
    }
}
