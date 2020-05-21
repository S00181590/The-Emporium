using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshMover))]
public class NavMeshMover : MonoBehaviour
{
    protected NavMeshAgent agent;
  

    public virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void MoveTo(Vector3 postion)
    {
        agent.SetDestination(postion);
    }
    public void MoveTo(GameObject gameObject)
    {
        MoveTo(gameObject.transform.position);
    }
    public void Stop()
    {
        agent.isStopped = true;
    }

}
