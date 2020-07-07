using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
     PlayerStats  playerstats;
    // Start is called before the first frame update
    void Start()
    {
        playerstats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("EnemyArrow"))
        {
           playerstats.PlayersHealth -= 10;

        }

        if (other.gameObject.tag.Equals("GreenSlimeAttack"))
        {
            playerstats.PlayersHealth -= 10;
            playerstats.PlayersStamina -= 15;

        }

        if (other.gameObject.tag.Equals("RedSlimeAttack"))
        {
            playerstats.PlayersHealth -= 20;

        }

        if (other.gameObject.tag.Equals("BlueSlimeAttack"))
        {
            playerstats.PlayersHealth -= 10;
            playerstats.PlayersMana -= 10;
        }

        if (other.gameObject.tag.Equals("EnemyArrow"))
        {
            playerstats.PlayersHealth -= 10;

        }
    }
}
