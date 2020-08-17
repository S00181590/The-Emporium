using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public int portalID;
     float Portalcooldown=0;
    public Animator animator;



     void Update()
    {
        if (Portalcooldown > 0)
        {
            Portalcooldown -= Time.deltaTime;
            Debug.Log(Portalcooldown);
        }
    }


     void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Portalcooldown <=0)
        {
            foreach (Portal portalid in FindObjectsOfType<Portal>())
            {
                if(portalid.portalID == portalID && portalid!=this)
                {
                    portalid.Portalcooldown = 2;
                    Vector3 postion = portalid.gameObject.transform.position;
                    other.gameObject.transform.position = postion;
                }
            }

        }
    }
}