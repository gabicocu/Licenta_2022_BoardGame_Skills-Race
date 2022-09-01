using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    Transform[] childObjects;
    public List<Transform> childNodeList = new List<Transform>();

    private void Start()
    {
        FillNodes();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        FillNodes();

        for (int i = 0; i < childNodeList.Count; i++)
        {
            Vector3 currentPos = childNodeList[i].position;
            if (i > 0) // modify the for to start from 1
            {
                Vector3 prevPos = childNodeList[i - 1].position;
                Gizmos.DrawLine(prevPos, currentPos);
            }
        }
    }

    void FillNodes()
    {
        childNodeList.Clear();
        childObjects = GetComponentsInChildren<Transform>();
        foreach(Transform child in childObjects)
        {
            if (child != this.transform) // if is not the parent(empty, the route)
            {
                childNodeList.Add(child);
            }
        }
    }
}
