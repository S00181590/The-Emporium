using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float attackrate;
    public bool beam, canAttack = false;
    public GameObject projechtile;
    public float fielOfView;
    public GameObject Target;
    public int damage;
    public List<GameObject> ProjechtileSpawner;

    List<GameObject> lastProjechtiles = new List<GameObject>();

    float fireTimer = 0.0f;

    private void Start()
    {
        Target = GameObject.Find("Character");
    }
    // Update is called once per frame
    void Update()
    {
        if (canAttack)
        {
            //if (!Target)
            //{
            //    if (beam)
            //        removeLastProjetiles();
            //    return;

            //}

            if (beam && lastProjechtiles.Count <= 0)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position));
                if (angle < fielOfView)
                {
                    SpawnProjectiles();
                }

                //if (angle > fielOfView)
                //{
                //    removeLastProjetiles();
                //}
            }
            else if (beam && lastProjechtiles.Count > 0)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position));

                if (angle > fielOfView)
                {
                    while (lastProjechtiles.Count > 0) 
                    {
                        Destroy(lastProjechtiles[0]); lastProjechtiles.RemoveAt(0);
                    }
                }


                //if (angle < fielOfView)
                //{
                    
                //    SpawnProjectiles();
                //    fireTimer = 0.0f;

                //}
            }
            else
            {
                fireTimer += Time.deltaTime;

                if (fireTimer >= attackrate)
                {

                    float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(Target.transform.position - transform.position));

                    if (angle < fielOfView)
                    {
                        SpawnProjectiles();

                        fireTimer = 0.0f;
                    }
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
            canAttack = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canAttack = false;
    }

    void SpawnProjectiles()
    {
        if (!projechtile)
        {
            return;
        }

        lastProjechtiles.Clear();

        for (int i = 0; i < ProjechtileSpawner.Count; i++)
        {
            if (ProjechtileSpawner[i])
            {
                GameObject proj = Instantiate(projechtile, ProjechtileSpawner[i].transform.position,
                    Quaternion.Euler(ProjechtileSpawner[i].transform.forward)) as GameObject;
                proj.GetComponent<BaseProjectile>().fireProjechtile(ProjechtileSpawner[i], Target, damage);

                lastProjechtiles.Add(proj);
            }
        }
    }

    //public void SetTheTarget(GameObject target)
    //{
    //    Target = target;
    //}
    void removeLastProjetiles()
    {
        while (lastProjechtiles.Count > 0)
        {
            Destroy(lastProjechtiles[0]);
            lastProjechtiles.RemoveAt(0);
        }
    }
}

