using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjechtilies : BaseProjectile
{
    Vector3 direction;
    // GameObject Gametarget;
    //  GameObject Shooter;
    //int Damage;
    //Vector3 Direction;
    bool canFire;

    void Update()
    {
        if (canFire)
        {
            transform.position += direction * (speed * Time.deltaTime);
        }
    }

    public override void fireProjechtile(GameObject Shoterobjecht, GameObject target, int damage/*, float attackspeed*/)
    {
        if (Shoterobjecht && target)
        {
            direction = (target.transform.position - Shoterobjecht.transform.position).normalized;
            canFire = true;
            //Shooter = Shoterobjecht;
            //Gametarget = target;
            // Damage = damage;
            // Destroy(gameObject, 10f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BaseProjectile>() == null)
            Destroy(gameObject);
    }



}

