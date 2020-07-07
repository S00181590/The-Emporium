using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float AttackRate;
    public bool beam, AbletoAttack = false;
    public GameObject Projechtile;
    public float FieldOfView;
    public GameObject Target;
    public int DamageAmount;
    public List<GameObject> ProjechtileSpawner;

    List<GameObject> EnemyLastAttack = new List<GameObject>();

    float FireRateTimer = 0.0f;

    private void Start()
    {
        Target = GameObject.Find("Character");
    }
    void Update()
    {
        if (AbletoAttack)
            if(!Target)
            {
                if (beam)
                    RemoveEnemeyfinalProjectiles();
                return;
            }


        if(beam && EnemyLastAttack.Count <=0)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position));
            if(angle < FieldOfView)
            {
                SpawnEnemeyProjectiles();
            }
            if (angle > FieldOfView)
            {
                RemoveEnemeyfinalProjectiles();
            }
        }

        else if (beam && EnemyLastAttack.Count >0)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position));
            if(angle > FieldOfView)
            {
                while(EnemyLastAttack.Count >0)
                {
                    Destroy(EnemyLastAttack[0]); EnemyLastAttack.RemoveAt(0);
                }
            }

            if (angle < FieldOfView)
            {
                SpawnEnemeyProjectiles();
                FireRateTimer = 0.0f;
            }
        }

        else
        {
            FireRateTimer += Time.deltaTime;
            if(FireRateTimer >= AttackRate)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position));
                if(angle <FieldOfView)
                {
                    SpawnEnemeyProjectiles();
                    FireRateTimer = 0.0f;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag =="Player")
        {
            AbletoAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag =="Player")
        {
            AbletoAttack = false;
        }
    }

    void SpawnEnemeyProjectiles()
    {
        if (!Projechtile)
        {
            return;
        }

        EnemyLastAttack.Clear();

        for (int i = 0; i < ProjechtileSpawner.Count; i++)
        {
            if (ProjechtileSpawner[i])
            {
                GameObject projectile = Instantiate(Projechtile, ProjechtileSpawner[i].transform.position,
                   Quaternion.Euler(ProjechtileSpawner[i].transform.forward)) as GameObject;
                projectile.GetComponent<BaseProjectile>().FireProjectileNow(ProjechtileSpawner[i], Target, DamageAmount, AttackRate);

                EnemyLastAttack.Add(projectile);
            }
        }
    }
    public void SetTheTarget(GameObject target)
    {
        Target = target;
    }

    void RemoveEnemeyfinalProjectiles()
    {
        while (EnemyLastAttack.Count >0)
        {
            Destroy(EnemyLastAttack[0]);
            EnemyLastAttack.RemoveAt(0);
        }
    }

  
}
