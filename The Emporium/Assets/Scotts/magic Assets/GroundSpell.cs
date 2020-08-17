using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpell : MonoBehaviour
{

    public GameObject spell;
    public GameObject explosinEffecht;
    public AudioSource GroundSound;
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
       // GroundSound.Play();
        Destroy(this.gameObject);

    }


}



