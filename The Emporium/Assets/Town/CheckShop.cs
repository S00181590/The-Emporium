using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckShop : MonoBehaviour
{

    private void Awake()
    {
        SceneManager.LoadScene("ShopScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("WorldScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Additive);

        
    }
}
