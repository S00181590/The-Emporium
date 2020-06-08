using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UIElements;

public class NPCDialogueInteraction : MonoBehaviour
{

    public Canvas Npccanvas;
    private bool isActive = false;

    private void Update()
    {
         if(Input.GetKeyDown(KeyCode.E))
        {
            isActive = !isActive;

            Npccanvas.gameObject.SetActive(true);
        }
    }
}
