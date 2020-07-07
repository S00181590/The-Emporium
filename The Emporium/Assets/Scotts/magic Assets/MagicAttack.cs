using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    public GameObject spell;
   
   
    EnemeyHealth enemeyHealth;
    public float projectileSpeed;
    PlayerStats playerStats;

    //public float movementspeed = 5f;
    //public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(
        //    transform.position.x + (movementspeed * Time.deltaTime),
        //    transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Z) && playerStats.PlayersMana > 0)
        {

            GameObject FireBall = Instantiate(spell, transform);
            Rigidbody rb = FireBall.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
            playerStats.PlayersMana -= 10;


        }

        if (playerStats.PlayersMana < playerStats.MaxMana)
        {
            {
                playerStats.PlayersMana += 5 * Time.deltaTime;
            }
        }
    }

    
}
