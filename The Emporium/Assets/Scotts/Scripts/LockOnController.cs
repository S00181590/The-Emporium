using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockOnController : MonoBehaviour
{

    Camera cam;
    EnemyLockon target;
    Image image;
   public bool LockedOnTarget;

    int LockedOnEnemys;

    public static List<EnemyLockon> allnearbyEnemys = new List<EnemyLockon>();

    // Start is called before the first frame update
   public void Start()
    {
        cam = Camera.main;
        image = gameObject.GetComponent<Image>();
        LockedOnTarget = false;
        LockedOnEnemys = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //r to lockon
        if (Input.GetKeyDown(KeyCode.F) && !LockedOnTarget)
        {
            if (allnearbyEnemys.Count >= 1)
            {
                LockedOnTarget = true;
                image.enabled = true;

                LockedOnEnemys = 0; //setting  lock on to the first enemy in the list
                target = allnearbyEnemys[LockedOnEnemys];
            }
        }

        //turing of lockon 
        else if ((Input.GetKeyDown(KeyCode.F) && LockedOnTarget || allnearbyEnemys.Count == 0))
            {
            LockedOnTarget = false;
            image.enabled = false;
            LockedOnEnemys = 0;
            target = null;
        }

        //switching target 
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(LockedOnEnemys == allnearbyEnemys.Count -1)
            {
                LockedOnEnemys = 0;
                target = allnearbyEnemys[LockedOnEnemys];
            }
            else
            {
                LockedOnEnemys++;
                target = allnearbyEnemys[LockedOnEnemys];

            }
        }

        if(LockedOnTarget)
        {
            target = allnearbyEnemys[LockedOnEnemys];
            gameObject.transform.position = cam.WorldToScreenPoint(target.transform.position);

            gameObject.transform.Rotate(new Vector3(0, 0, -1));
        }
    }
}
