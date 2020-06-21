using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireSpell : MonoBehaviour
{
    public GameObject Target;
    EnemeyHealth enemeyHealth;
    PlayerStats playerStats;
    PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {


            Vector3 targetocation = new Vector3(Target.transform.position.x, Target.transform.position.y,
                Target.transform.position.z);
            this.transform.LookAt(targetocation);

            float distance = Vector3.Distance(Target.transform.position, this.transform.position);

            if (distance > 3f)
            {
                transform.Translate(Vector3.forward * 20.0f * Time.deltaTime);
            }
            else
            {
                HitTarget();
            }
        }
    }
    void HitTarget()
    {
        Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("FireSpell"))
        {
            enemeyHealth.health -= 10;
        }
    }
}
