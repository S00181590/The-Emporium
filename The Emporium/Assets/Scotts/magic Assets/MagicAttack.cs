using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    public GameObject spell;
    public GameObject spell2;
    public GameObject spell3;
    EnemeyHealth enemeyHealth;
    public float projectileSpeed;
    PlayerStats playerStats;
    weaponSwitcher weaponSwitcher;
    //public Transform magicSpawnPosition;
    //public float movementspeed = 5f;
    //public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        weaponSwitcher = GetComponent<weaponSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
    //    //transform.position = new Vector3(
    //    //    transform.position.x + (movementspeed * Time.deltaTime),
    //    //    transform.position.y, transform.position.z);

    //    if (Input.GetKeyDown(KeyCode.Z) && playerStats.PlayersMana > 0 && weaponSwitcher.EquippedWeapon == 4)
    //    {

    //        GameObject FireBall = Instantiate(spell, transform);
    //        Rigidbody rb = FireBall.GetComponent<Rigidbody>();
    //        rb.velocity = magicSpawnPosition.transform.position * projectileSpeed;//speed the fire ball travels and direction 
    //        //rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
    //        playerStats.PlayersMana -= 10;


    //    }
        if (Input.GetKeyDown(KeyCode.X) )
        {

            GameObject IceAttack = Instantiate(spell2, transform);
            Rigidbody rb = IceAttack.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
            playerStats.PlayersMana -= 15;


        }
        if (Input.GetKeyDown(KeyCode.C) && playerStats.PlayersMana > 0 && weaponSwitcher.EquippedWeapon == 6)
        {
            Groundattack();
            //GameObject GroundAttack = Instantiate(spell3, transform);
            //Rigidbody rb = GroundAttack.GetComponent<Rigidbody>();
            //rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
            //playerStats.PlayersMana -= 20;


        }
        if (playerStats.PlayersMana < playerStats.MaxMana)
        {
            {
                playerStats.PlayersMana += 5 * Time.deltaTime;
            }
        }
    }

   void  Groundattack()
    {
        GameObject GroundAttack = Instantiate(spell3, transform);
        Rigidbody rb = GroundAttack.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
        playerStats.PlayersMana -= 20;
    }
    
}
