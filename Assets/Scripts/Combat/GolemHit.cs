using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemHit : MonoBehaviour
{
    // Start is called before the first frame update
    public SphereCollider sphere;
    public LayerMask wallLayer;
    void Start()
    {
        sphere = GetComponent<SphereCollider>();
        Hit();
    }

    void Hit(){
        // Collider[] coll = Physics.OverlapSphere(transform.position,sphere.radius,wallLayer);

        // if(coll[0] != null)
        // {
        //     coll[0].GetComponent<Wall>().Hit(transform.position);
        // }
    }
}
