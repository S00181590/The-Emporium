using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;
    public int  movespeed;
    public int  stoppingDistance = 5;
    public int maxfollowdistance = 10;
     
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        if(Vector3.Distance(transform.position,Player.position)>=stoppingDistance)
        {
            transform.position += transform.forward * movespeed * Time.deltaTime;
        }

        if(Vector3.Distance(transform.position,Player.position) <= maxfollowdistance)
        {

        }
    }

   
}
