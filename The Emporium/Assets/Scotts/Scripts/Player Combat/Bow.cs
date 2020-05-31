using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{

    //public Camera cam;
    public GameObject arrowPrefabs;
    public Transform arrowSpawnPosition;
    public float shootpower = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))//mouse button
        {
            GameObject start = Instantiate(arrowPrefabs, arrowSpawnPosition.position, Quaternion.identity);
            Rigidbody rb = start.GetComponent<Rigidbody>();
           // rb.velocity = arrowSpawnPosition.transform.forward * shootpower;
            rb.velocity = arrowSpawnPosition.transform.position * shootpower;
        }
    }
}
