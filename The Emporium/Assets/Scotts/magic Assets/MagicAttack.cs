using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    public GameObject spell1;
    public GameObject spell2;
    public GameObject spell3;
    public GameObject spell4;
    EnemeyHealth enemeyHealth;
    public float projectileSpeed;
    PlayerStats playerStats;
    //  weaponSwitcher weaponSwitcher;
    public Transform magicSpawnPosition;
    //public float movementspeed = 5f;
    //public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        // weaponSwitcher = GetComponent<weaponSwitcher>();
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (playerStats.PlayersMana >= 10)
            {

                GameObject FireBall = Instantiate(spell1, magicSpawnPosition);
                FireBall.transform.parent = null;
                FireBall.transform.localPosition = Vector3.zero;
                FireBall.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
                FireBall.transform.localPosition = new Vector3(magicSpawnPosition.position.x, magicSpawnPosition.position.y, magicSpawnPosition.position.z);
                Rigidbody rb = FireBall.GetComponent<Rigidbody>();
                rb.velocity = magicSpawnPosition.forward * projectileSpeed; //speed the fire ball travels and direction 
                playerStats.PlayersMana -= 10;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerStats.PlayersMana >= 15)
            {

                GameObject RockAttack = Instantiate(spell3, magicSpawnPosition);
                RockAttack.transform.parent = null;
                RockAttack.transform.localPosition = Vector3.zero;
                RockAttack.transform.localPosition = new Vector3(0, 0, 0);
                RockAttack.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                RockAttack.transform.localPosition = new Vector3(magicSpawnPosition.position.x, magicSpawnPosition.position.y, magicSpawnPosition.position.z + 1);
                Rigidbody rb = RockAttack.GetComponent<Rigidbody>();
                rb.velocity = magicSpawnPosition.forward * projectileSpeed;//speed the fire ball travels and direction 
                playerStats.PlayersMana -= 15;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            {

                Groundattack();
                //playerStats.PlayersMana -= 20;
                //GameObject GroundAttack = Instantiate(spell3, transform);
                //Rigidbody rb = GroundAttack.GetComponent<Rigidbody>();
                //rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
            }


        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            GameObject shield = Instantiate(spell4, transform);
            shield.transform.parent = null;
            shield.transform.localPosition = Vector3.zero;
            shield.transform.localPosition = new Vector3(magicSpawnPosition.position.x,magicSpawnPosition.position.y + -1f, magicSpawnPosition.position.z);
            shield.transform.localScale = new Vector3(1f, 1f, 1f);
            shield.transform.SetParent(magicSpawnPosition);
            //Rigidbody rb = shield.GetComponent<Rigidbody>();
            //rb.velocity = magicSpawnPosition.transform.position;
            playerStats.PlayersMana -= 50;
            Destroy(shield, 20.0f);

        }
       
    }

    void Groundattack()
    {
        if (playerStats.PlayersMana >= 20)
        {
            GameObject GroundAttack = Instantiate(spell3, transform);
            Rigidbody rb = GroundAttack.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
            playerStats.PlayersMana -= 20;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "RedSlimeAttack":
                Destroy(this.gameObject);
                break;
            case "GreenSlimeAttack":
                Destroy(this.gameObject);
                break;
            case "BlueSlimeAttack":
                Destroy(this.gameObject);
                break;
        }
    }
}
