using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public PathNode NextNode;
    public Color PathDebugColor;

    private void OnDrawGizmos()
    {
        if(NextNode != null)
        {
            Gizmos.color = PathDebugColor;
            Gizmos.DrawLine(transform.position, NextNode.transform.position);
        }
    }
}
