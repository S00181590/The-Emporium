using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeOptionUIButtonclick : MonoBehaviour
{
    DialougeManger dialougeManger;
    DialogueObjecht dialogueObjecht;
    [SerializeField] Text dialogueText;

   public void DialougebuttonSetup(DialougeManger _DialougeManger, DialogueObjecht _dialogueObjecht , string _dialoguetext)
    {
        dialougeManger = _DialougeManger;
        dialogueObjecht = _dialogueObjecht;
        dialogueText.text = _dialoguetext;
    }

    public void SelectOption()
    {
        dialougeManger.DialogueOptionsSelcted(dialogueObjecht);
    }
}
