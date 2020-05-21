using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    public static SavesManager instance;
    private void Awake()
    {
        if(instance == null )
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else if(instance !=this)
        {
            //should only ever have one instance if more then one insance it get destroyed here 
            Destroy(this.gameObject);
        }
                
                
    }
}


