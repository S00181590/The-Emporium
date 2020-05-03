using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject cam, character;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");

        character = GameObject.Find("Character"); 

        cam.transform.parent = gameObject.transform;

        cam.transform.localPosition = new Vector3(0, 7, -9);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x,character.transform.position.y, transform.position.z);

        cam.transform.LookAt(gameObject.transform);
    }
}
