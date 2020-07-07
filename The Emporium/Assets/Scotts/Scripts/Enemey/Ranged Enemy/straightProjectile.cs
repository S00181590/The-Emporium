using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straightProjectile : BaseProjectile
{
    public float Projechtilelegnth;

    GameObject mlaucher;
    //GameObject Gametarget;
    // GameObject Shooter;
    // int Damage;
    // Vector3 Direction;
    // float Shootertimer;
    // float AttackSpeed;


    void Update()
    {
        //  Shootertimer += Time.deltaTime;

        if (mlaucher)
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, transform.position + (mlaucher.transform.forward * Projechtilelegnth));



            //if (Physics.Raycast(Shooter.transform.position, Shooter.transform.forward, out hit, Projechtilelegnth))
            //{
            //    if (Shootertimer >= AttackSpeed)
            //    {

            //    }
            //}

        }
    }


    public override void fireProjechtile(GameObject Shoterobjecht, GameObject target, int damage/*, float attackrate*/)
    {
        if (Shoterobjecht)
        {
            mlaucher = Shoterobjecht;
            transform.SetParent(mlaucher.transform);
            // Shooter = target;
            // Damage = damage;
            // AttackSpeed = attackrate;
            // Shootertimer = 0.0f;
        }
    }
}