using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManger : MonoBehaviour
{
    [SerializeField] Canvas DialougeCanvas;
    [SerializeField] Text DialougeText;
    [SerializeField] DialogueObjecht startdialougeobjecht;
    [SerializeField] Transform dialogueOptionsParent;
    [SerializeField] GameObject dialogueOptionsButtonPrefab;
    [SerializeField] GameObject dialogueOptionsContainer;

    bool dialogueOptionsSelcted = false;

    public void LoadDialouge( )
    {
        StartCoroutine(DisplayDialougeText(startdialougeobjecht));
    }

    public void LoadDialouge(DialogueObjecht _dialogueObjecht)
    {
        StartCoroutine(DisplayDialougeText(_dialogueObjecht));
    }

    public void DialogueOptionsSelcted(DialogueObjecht selecteddialogue)
    {
        dialogueOptionsSelcted = true;
        LoadDialouge (selecteddialogue);
        
    }

    IEnumerator DisplayDialougeText(DialogueObjecht _dialogueObjecht)
    {
        yield return null;
        List<GameObject> spawnedDialougueButtons = new List<GameObject>();//deleting duplicat choices
        DialougeCanvas.enabled = true;

        foreach (var dialogue in _dialogueObjecht.dialoguetrees)
        {
            DialougeText.text = dialogue.dialougueText;

            if (dialogue.DialogueChocies.Count ==0)
            { 
                yield return new WaitForSeconds(dialogue.dialougueDisplayTime);
            }
            else//opeing options panel ui 
            {
                dialogueOptionsContainer.SetActive(true);
                foreach (var option in dialogue.DialogueChocies)
                {
                    GameObject newButton = Instantiate(dialogueOptionsButtonPrefab, dialogueOptionsParent);//spawns dialoughe choice button 
                    spawnedDialougueButtons.Add(newButton);
                    newButton.GetComponent<DialougeOptionUIButtonclick>().DialougebuttonSetup(this,option.nextDialogue,option.dialogueChocie);//loading in the dialoughe choice

                }

                while (!dialogueOptionsSelcted)
                {
                    yield return null;
                }
                break;
            }
        }
        dialogueOptionsContainer.SetActive(false);
        DialougeCanvas.enabled = false;
        dialogueOptionsSelcted = false;

        spawnedDialougueButtons.ForEach(x => Destroy(x));//destorying duplicate buttons
    }

}
