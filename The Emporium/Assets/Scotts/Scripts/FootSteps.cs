//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class FootSteps : MonoBehaviour
//{
//    public AudioClip GroundSound;
//    public AudioClip WaterSound;
//    public AudioClip MudSound;
//    CharacterController characterController;

//    public AudioSource audioSource;
//    bool ismoveing;

//     void Start()
//    {
//        characterController = GetComponent<CharacterController>();
//        audioSource = GetComponent<AudioSource>();
//    }
//    void Update()
//    {
//        if (characterController.isGrounded == true && characterController.velocity.magnitude >2f &&audioSource.isPlaying ==false)
//        {
//            audioSource.Play();
//            //ismoveing = true;
//            //if (ismoveing)
//            //{
//            //    if (!audioSource.isPlaying)
//            //    {
//            //        audioSource.Play();
//            //    }
//            //    else
//            //        audioSource.Stop();
//            //}
//        }

//        else
//        {
//            ismoveing = false;
//            audioSource.Stop()
//        }

//    }

    
//}
