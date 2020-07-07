using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullettracking : BaseProjectile
{
    GameObject Gametarget;
    // GameObject Shooter;
    // int Damage;

   // Vector3 Direction;

    //  bool canFire;

    void Update()
    {
        if (Gametarget)
        {
            // Direction = Gametarget.transform.position;

            transform.position = Vector3.MoveTowards(transform.position, Gametarget.transform.position, speed * Time.deltaTime);
        }
        //else
        //{
        //    if (transform.position == Direction)
        //    {
        //        Destroy(gameObject);
        //    }
        //}


    }

    //public   void FireProjechtile(GameObject Shoterobjecht, GameObject target, int damage/*, float attackspeed*/)
    //{
    //    if (target)
    //    {
    //        Gametarget = target;
    //       // Direction = target.transform.position;
    //        //Shooter = Shoterobjecht;
    //        //Damage = damage;
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<BaseProjectile>() == null)
            Destroy(gameObject);
    }
    
    public override void fireProjechtile(GameObject Shoterobjecht, GameObject target, int damage)
    {
        if (target)
        {
            Gametarget = target;
             //Direction = target.transform.position;
            //Shooter = Shoterobjecht;
            //Damage = damage;
        }
    }
}
