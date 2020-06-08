using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiInteract : MonoBehaviour
{
    [SerializeField] UnityEvent OnInteract;
    [SerializeField] Canvas canvas;

   
     void Awake()
    {
      
        canvas.enabled = false;
    }

     void OnEnable()
    {
        //NPCDialogueInteraction.OnInteract += Interact;
        //NPCDialogueInteraction.OnEnterInteactable -= InteractionshowUI;
        //NPCDialogueInteraction.OnEnterInteactable -= InteractionHideUI;
    }
 
    void Interact()
    {
        OnInteract.Invoke();
    }
    void InteractionshowUI()
    {
     
        canvas.enabled = true;
    }

    void InteractionHideUI()
    {
        canvas.enabled = false;
    }
}
