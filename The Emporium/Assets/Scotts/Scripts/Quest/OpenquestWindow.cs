using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenquestWindow : MonoBehaviour
{
    bool isactive;
    public GameObject openquestwindow;
    public bool playerInRange;
    QuestGiver questGiver;

    void Update()
    {

        if (Input.GetKey(KeyCode.R) && playerInRange)
        {
            if (openquestwindow.activeInHierarchy)
            {
                openquestwindow.SetActive(false);
                questGiver.Titletext.text = questGiver.quest.title;
                questGiver.descriptiontext.text = questGiver.quest.Description;
                questGiver.Goldtext.text = questGiver.quest.GoldReward.ToString();
                //questGiver.Itemtext.text = questGiver.quest.ItemReward.ToString();

                if (Cursor.lockState != CursorLockMode.None)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
            }
            else
            {
                openquestwindow.SetActive(true);
                if (Cursor.lockState != CursorLockMode.None)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
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
            openquestwindow.SetActive(false);
        }
    }
}
