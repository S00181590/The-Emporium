using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    private Animator _animator;
    private GameObject _player;
    private bool _collidedWithThePlayer;


     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject ==_player)
        {
            _animator.SetBool("IsNearThePlayer", true);
        }
     
    }

     void OnCollisionEnter(Collision other)
     {
        if(other.gameObject == _player)
        {
            _collidedWithThePlayer = true;
        }
     }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject == _player)
        {
            _collidedWithThePlayer = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject ==_player)
        {
            _animator.SetBool("IsNearThePlayer", false);
        }
    }

    private void Attack()
    {
        if(_collidedWithThePlayer)
        {
            _player.GetComponent<Health>().TakeDamage(10);
        }
    }
}
