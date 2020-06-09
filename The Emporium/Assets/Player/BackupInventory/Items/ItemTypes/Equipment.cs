using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : Item
{
    public override void Use()
    {
        GameObject equip = GameObject.Find(title);

        equip.SetActive(true);
    }
}
