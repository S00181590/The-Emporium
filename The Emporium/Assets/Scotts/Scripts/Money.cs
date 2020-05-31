using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

    public Inventory playerInventory;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInventory.playersMoney += 1;
            Destroy(this.gameObject);
        }
    }
}
