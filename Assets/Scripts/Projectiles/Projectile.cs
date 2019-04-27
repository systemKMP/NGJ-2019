using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    
    private Rigidbody rigidbody;
    

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        // Fire(projectileSpeed, Quaternion.identity);
    }
    public void Fire(float force, Quaternion direction){
        transform.rotation = direction;
        rigidbody.AddForce(force * transform.forward,ForceMode.Impulse);
    }
    
    void OnCollisionEnter(Collision coll){
        Stick(coll.transform);
    }
    
    void Stick(Transform newParent){
        rigidbody.isKinematic = true;
        transform.parent = newParent;
    }
}
