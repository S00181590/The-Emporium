using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    //public Camera cam;
    public GameObject arrowPrefabs;
    public Transform arrowSpawnPosition;
    public float shootpower = 25f;

    public GameObject mainCam, AimCamL;

    public bool aiming;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.Find("Main_ThirdPersonCamera");
        AimCamL = GameObject.Find("RangedAimL_Cam");

        aiming = false;

        AimCamL.SetActive(aiming);

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(1))
        {
            aiming = !aiming;

            AimCamL.SetActive(!AimCamL.activeSelf);

            mainCam.SetActive(!mainCam.activeSelf);
        }

        //if(Input.GetMouseButtonUp(1))
        //{
        //    aiming = false;

        //    AimCamL.SetActive(!AimCamL.activeSelf);

        //    mainCam.SetActive(!mainCam.activeSelf);
        //}

        if (aiming)
        {
            //PlayerMovement player = GameObject.Find("Character").GetComponent<PlayerMovement>();

            //player.rotationSpeed = 0.1f;
            
            if (Input.GetMouseButtonDown(0))//mouse button
            {
                GameObject start = Instantiate(arrowPrefabs, arrowSpawnPosition.position, Quaternion.identity);
                Rigidbody rb = start.GetComponent<Rigidbody>();
                // rb.velocity = arrowSpawnPosition.transform.forward * shootpower;
                rb.velocity = arrowSpawnPosition.transform.position * shootpower;
            }
        }
    }
}
