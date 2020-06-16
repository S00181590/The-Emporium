using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPathFollow : NavMeshMover
{
    public PathNode CurrentNode;
    public float followamount;
    public override void Start()
    {
        base.Start();
        
    }

    void MovetoPathNode()
    {
        if (CurrentNode != null)
        {
            MoveTo(CurrentNode.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="PathNode" && other.gameObject.name == CurrentNode.gameObject.name)
        {
            CurrentNode = other.gameObject.GetComponent<PathNode>().NextNode;
            MovetoPathNode();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;//drawing the color of the path node 
        Gizmos.DrawWireSphere(transform.position, followamount);//if assigned on an emeny will show his dection field 
    }

}
