using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallTake2 : MonoBehaviour
{

    public GameObject spell;
    public GameObject explosinEffecht;
    public AudioSource explosionsound;
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
        explosionsound.Play();
            Destroy(gameObject);
      
    }
































    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Z)&& playerStats.PlayersMana >0 )
        //{

        //    GameObject FireBall = Instantiate(spell, transform);
        //    Rigidbody rb = FireBall.GetComponent<Rigidbody>();
        //    rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
        //    playerStats.PlayersMana -= 10;


        //}

        //if (playerStats.PlayersMana < playerStats.MaxMana  )
        //{
        //      {
        //        playerStats.PlayersMana += 5 * Time.deltaTime;      
        //      }
        //}
    }
}
