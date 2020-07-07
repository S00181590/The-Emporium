//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class fireballontrigger : MonoBehaviour
//{

//    public GameObject explosinEffecht;
//    public AudioSource explosionsound;
//    EnemeyHealth enemeyHealth;


//    private void Start()
//    {
//        explosionsound = GetComponent<AudioSource> ();
//    }
//    void OnTriggerEnter(Collider other)
//    {
//        if(tag =="Enemy")
//        {
//            enemeyHealth.health -= 15;
//            Destroy(other.gameObject);
//            explosionsound.Play();
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }
//}
