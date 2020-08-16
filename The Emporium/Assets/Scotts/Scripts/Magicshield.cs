using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magicshield : MonoBehaviour
{

    public GameObject spell;
    public GameObject explosinEffecht;
    public AudioSource explosionsound;
    //AudioSource audio;


    PlayerStats playerStats;
    

    public Transform magicSpawnPosition;
    void Start()
    {
        //audio = GetComponent<AudioSource>();
        playerStats = GetComponent<PlayerStats>();
     
        // GetComponent<AudioSource>().playOnAwake =false;
        // GetComponent<AudioSource>().clip = explosionsound;
    }

    void Update()
    {
        //transform.position = new Vector3(
        //    transform.position.x + (movementspeed * Time.deltaTime),
        //    transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Alpha4) && playerStats.PlayersMana >=50)
        {
           

              GameObject shield = Instantiate(spell, transform);
              Rigidbody rb = shield.GetComponent<Rigidbody>();
            rb.velocity = magicSpawnPosition.position;
              playerStats.PlayersMana -= 50;
              Destroy(spell, 60.0f);


        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("BlueSlimeAttack"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("RedSlimeAttack"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("RedSlimeAttack"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag.Equals("GreenSlimeAttack"))
        {
            Destroy(other.gameObject);
        }
       
    }


}




