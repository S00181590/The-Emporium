using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Questgola 
{
    public GoalType goalType;
    public int requiredamount;
    public int currentamount;

        public bool IsGoalReached()
        {
            return (currentamount >= requiredamount);
     
        }

    public void EnemeyKills()
    {
        if (goalType == GoalType.Kill)
        {
            
            currentamount++;
        }
            
    }
    //public void OnTriggerEnter(Collider other)
    //{
       
        
    //        if (other.tag.Equals("Enemy")) 
    //        {
    //            EnemeyKills();
    //        }
        
    //}
        public void ItemCollected()
    {
        if (goalType == GoalType.Gathering)
        {
            currentamount++;

        }
    }
    public void crafting()
    {
        if (goalType == GoalType.crafting)
        {
            currentamount++;

        }
    }


}
public enum GoalType

{
    
    Kill,
    Gathering,
    crafting,
    adventure
}