using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallTake2 : MonoBehaviour
{

    public GameObject spell;
    public float projectileSpeed;

    

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.Z))
        {
            GameObject FireBall = Instantiate(spell, transform) as GameObject;
            Rigidbody rb = FireBall.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
        }
    }
}
