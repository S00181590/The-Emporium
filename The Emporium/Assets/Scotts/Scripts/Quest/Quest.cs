using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    public bool Isactivate;
    public string title;
    public string Description;
    public int GoldReward;
    public GameObject ItemReward;


    public Questgola goal;

    public void Complete()
    {
        Isactivate = false;
        Debug.Log(title + "completed");
        
    }
}
