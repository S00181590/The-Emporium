using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullettracking : NormalProjechtilies
{
    GameObject Gametarget;
    GameObject Shooter;
    int Damage;

    Vector3 Direction;
    bool canfire;

    void Update()
    {
        if(Gametarget)
        {
            Direction = Gametarget.transform.position;
        }

        else
        {
            if(transform.position == Direction)
            {
                Destroy(gameObject);
            }
        }
        
    }

    public void FireProjechtile(GameObject ShotterObjecht, GameObject target, int damage, float attackspeed)
    {
        if(target)
        {
            Gametarget = target;
            Direction = target.transform.position;
            Shooter = ShotterObjecht;
            Damage = damage;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<BaseProjectile>() == null)
        {
            Destroy(gameObject);
        }
    }
}
