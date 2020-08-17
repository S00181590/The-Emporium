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

    weaponSwitcher weaponSwitcher;
    public Transform magicSpawnPosition;
    void Start()
    {
        //audio = GetComponent<AudioSource>();
        playerStats = GetComponent<PlayerStats>();
        weaponSwitcher = GetComponent<weaponSwitcher>();
        // GetComponent<AudioSource>().playOnAwake =false;
        // GetComponent<AudioSource>().clip = explosionsound;
    }

    void Update()
    {
        //transform.position = new Vector3(
        //    transform.position.x + (movementspeed * Time.deltaTime),
        //    transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Z) && playerStats.PlayersMana > 0 )
        {

            GameObject FireBall = Instantiate(spell, transform);
            Rigidbody rb = FireBall.GetComponent<Rigidbody>();
            rb.velocity = magicSpawnPosition.transform.position * projectileSpeed;//speed the fire ball travels and direction 
            //rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
            playerStats.PlayersMana -= 10;


        }
    }

        void OnCollisionEnter(Collision other)
    {
       // explosionsound.Play();
        Destroy(this.gameObject);

    }


}





