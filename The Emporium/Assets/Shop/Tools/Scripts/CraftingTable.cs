using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    GameObject player, craftUI;

    public bool inrange = false;
    public bool cancelling = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Character");

        craftUI = GameObject.Find("CraftFrame");

        craftUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(inrange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                craftUI.SetActive(!craftUI.activeSelf);

                player.GetComponent<PlayerMovement>().cutscene = craftUI.activeSelf;
            }
        }
        else
        {
            craftUI.SetActive(false);

            player.GetComponent<PlayerMovement>().cutscene = false;
        }

        if(cancelling)
        {
            craftUI.SetActive(false);

            player.GetComponent<PlayerMovement>().cutscene = false;

            cancelling = false;
        }
    }

}
