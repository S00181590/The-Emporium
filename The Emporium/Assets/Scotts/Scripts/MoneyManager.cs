using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class MoneyManager : MonoBehaviour
{
    public Inventory playerInventory;
    public TextMeshProUGUI moneyDisplay;

    public void UpdatePlayersMone()
    {
        moneyDisplay.text = "" + playerInventory.playersMoney;
    }

}
