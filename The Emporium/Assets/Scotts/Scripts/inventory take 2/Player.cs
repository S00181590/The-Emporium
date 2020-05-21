//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Player : MonoBehaviour
//{
//    public InventoryObject inventory;

//    public void OnTriggerEnter(Collider other)
//    {
//        var item = other.GetComponent<Item>();//adding the item to the players inventory when hewalks over it 
//        if(item)
//        {
//            inventory.AddItem(item.item, 1);
//            Destroy(other.gameObject);
//        }
//    }
//    private void OnApplicationQuit()
//    {
//        inventory.Container.Clear();//clearing the players inventory when he quits the game 
//    }
//}
