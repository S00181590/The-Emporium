using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    GameObject player, craftUI, craftCanvas;

    Camera camera;

    public bool inrange = false;
    public bool cancelling = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        player = GameObject.Find("Character");

        craftUI = GameObject.Find("CraftFrame");

        craftCanvas = GameObject.Find("CraftCanvas");

        craftCanvas.GetComponent<Canvas>().worldCamera = camera;

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

                GameObject.Find("CraftingPanel").GetComponent<CraftingController>().SetNewCamera();
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
