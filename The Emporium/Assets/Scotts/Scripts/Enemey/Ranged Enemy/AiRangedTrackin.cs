using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRangedTrackin : MonoBehaviour
{
    public float trackingSpeed;
    public GameObject TargetSelcted = null;
    // Vector3 PlayersLastKnownLocation;
    Vector3 PlayersLastKnownLocation = Vector3.zero;
    Quaternion FiledOfViewRadius;



     void Update()
    {
      if(TargetSelcted)
        {
            if(PlayersLastKnownLocation != TargetSelcted.transform.position)
            {
                PlayersLastKnownLocation = TargetSelcted.transform.position;
                FiledOfViewRadius = Quaternion.LookRotation(PlayersLastKnownLocation - transform.position);

            }

            if(transform.rotation != FiledOfViewRadius)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, FiledOfViewRadius, trackingSpeed * Time.deltaTime);
            }
        }
    }

    bool SetTarget ( GameObject target)
    {
        if(target)
        {
            return false;
        }

        TargetSelcted = target;
        return true;
    }
}
