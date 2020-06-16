using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjechtilies : BaseProjectile
{
    Vector3 direction;
    GameObject Gametarget;
    GameObject Shotter;
    int DamageAmount;
    Vector3 Direction;
    bool CanFire;

   
    void Update()
    {
        if(CanFire)
        {
            transform.position += direction *(speed * Time.deltaTime);
        }
    }

    public override void FireProjectileNow(GameObject ShotterObjecht, GameObject target, int damage, float AttackRate)
    {
       if(ShotterObjecht && target)
        {
            direction = (target.transform.position - ShotterObjecht.transform.position).normalized;
            CanFire = true;
            Shotter = ShotterObjecht;
            Gametarget = target;
            DamageAmount = damage;
            Destroy(gameObject, 15f);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BaseProjectile>()==null)
        {
            Destroy(gameObject);
        }
    }
}
