//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[CreateAssetMenu (fileName ="New Consumable",menuName = "Items/Consumable")]
//public class ItemConsumable : Item
//{
//    public int heal = 0;//not every item will heal the player thats why it sets to 0 

//    public override void Use()
//    {
     
//        {
//            GameObject player = Inventory.instance.player;
//            Health playerHealth = player.GetComponent<Health>();

//            playerHealth.Heal(heal);//healing the player useing potion
//            Inventory.instance.RemoveItemFormInventory(this);
//        }
//    }
//}
