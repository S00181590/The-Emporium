using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenTextUI : MonoBehaviour
{
    [SerializeField] private Image dialiogleImage;

     void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player " )
        {
            dialiogleImage.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player ")
        {
            dialiogleImage.enabled = false;
        }
    }
}
