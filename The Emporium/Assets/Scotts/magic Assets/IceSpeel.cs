using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpeel : MonoBehaviour
{
    public GameObject spell;
    public GameObject explosinEffecht;
    public AudioSource IceSound;
    //AudioSource audio;

    public float projectileSpeed;
    PlayerStats playerStats;

    void Start()
    {
        //audio = GetComponent<AudioSource>();

        // GetComponent<AudioSource>().playOnAwake =false;
        // GetComponent<AudioSource>().clip = explosionsound;
    }




    void OnCollisionEnter(Collision other)
    {
       // IceSound.Play();
        Destroy(gameObject);

    }


}




