using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.rotation * Vector3.forward * 2.0f);
    }

}
