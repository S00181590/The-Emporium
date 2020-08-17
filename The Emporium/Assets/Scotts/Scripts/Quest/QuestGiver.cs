using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public PlayerStats player;
    public GameObject questwindow;
  
    public Text Titletext;
    public Text descriptiontext;
    public Text Goldtext;
    public Text Itemtext;
    public bool playerInRange;
    public void Update()
    {

        if (Input.GetKey(KeyCode.R) && playerInRange)
        {
            questwindow.SetActive(true);
            Titletext.text = quest.title;
             descriptiontext.text = quest.Description;
             Goldtext.text = quest.GoldReward.ToString();
             Itemtext.text = quest.ItemReward.ToString();
            //if (Cursor.lockState != CursorLockMode.None)
            //{
            //    Cursor.lockState = CursorLockMode.None;
            //}

        }
        else
            {
            questwindow.SetActive(false);
            //if (Cursor.lockState != CursorLockMode.None)
            //{
            //    Cursor.lockState = CursorLockMode.None;
            //}
        }
    }
    //public void populatequestwindow()
    //{
    //    if(questwindow.activeInHierarchy == true)
    //    {
    //        Titletext.text = quest.title;
    //        descriptiontext.text = quest.Description;
    //        Goldtext.text = quest.GoldReward.ToString();
    //        Itemtext.text = quest.ItemReward.ToString();
    //    }
    //}
    //questwindow.SetActive(true);
    //Titletext.text = quest.title;
    //descriptiontext.text = quest.Description;
    //Goldtext.text = quest.GoldReward.ToString();
    //Itemtext.text = quest.ItemReward.ToString();
 
    public void AcceptQuest()
    {
        questwindow.SetActive(false);
        quest.Isactivate = true;
        player.quest = quest;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            questwindow.SetActive(false);
        }
    }
}

