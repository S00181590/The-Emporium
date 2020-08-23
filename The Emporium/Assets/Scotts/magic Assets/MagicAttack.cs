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

                GameObject FireBall = Instantiate(spell1, transform);
                Rigidbody rb = FireBall.GetComponent<Rigidbody>();
                rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
                playerStats.PlayersMana -= 10;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (playerStats.PlayersMana >= 15)
            {

                GameObject IceAttack = Instantiate(spell2, transform);
                Rigidbody rb = IceAttack.GetComponent<Rigidbody>();
                rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
                playerStats.PlayersMana -= 15;
            }

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {

            {

                Groundattack();
                //playerStats.PlayersMana -= 20;
                //GameObject GroundAttack = Instantiate(spell3, transform);
                //Rigidbody rb = GroundAttack.GetComponent<Rigidbody>();
                //rb.velocity = transform.forward * projectileSpeed;//speed the fire ball travels and direction 
            }


        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            {

                GameObject shield = Instantiate(spell4, transform);
                Rigidbody rb = shield.GetComponent<Rigidbody>();
                rb.velocity = magicSpawnPosition.transform.position;
                playerStats.PlayersMana -= 50;
                Destroy(spell4, 60.0f);
            }


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
        if (other.gameObject.tag.Equals("RedSlimeAttack"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag.Equals("RedSlimeAttack"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag.Equals("GreenSlimeAttack"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag.Equals("BlueSlimeAttack"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag.Equals("RedSlimeAttack"))
        {
            Destroy(this.gameObject);
        }
    }
}
