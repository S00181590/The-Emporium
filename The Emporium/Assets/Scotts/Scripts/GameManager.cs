using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ItemList AllItemsInTheGame;
    public static GameManager Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (GameManager.Instance == null)
            GameManager.Instance = this;
    }


}
