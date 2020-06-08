using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewNpcDialouge", menuName = " newdialougetree/newdialouge", order = 0)]
public class DialogueObjecht : ScriptableObject
{
    public List<Dialoguetree> dialoguetrees = new List<Dialoguetree>();

    public DialogueObjecht FinishDialouge;


    [System.Serializable]
    public struct Dialoguetree
    {
        public string dialougueText;
        public float dialougueDisplayTime;

        public List<DialogueChocies> DialogueChocies;
    }
    
    [System.Serializable]
    public struct DialogueChocies
    {
        public string dialogueChocie;

        public DialogueObjecht nextDialogue;
    }

    
}
