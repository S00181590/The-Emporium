﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject cam, character, pivot;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("CM_ThirdPerson");

        character = GameObject.Find("Character");

        pivot = new GameObject("Pivot");

        pivot.transform.parent = character.transform;

        pivot.transform.localPosition = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        //float x = Input.GetAxis("X") * 20f * Time.deltaTime;


        //character.transform.Rotate(new Vector3(0, x, 0));

        //gameObject.transform.localposition = new Vector3(transform.position.x,character.transform.position.y, transform.position.z);
    }


}
