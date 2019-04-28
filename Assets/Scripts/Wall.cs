using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject destroyedWall;
    
    public Transform direction;
    public float force;
    public float damageRadius;
    public float forceForward;
    public float forceOutward;


    public void Start(){
        // Hit(direction.position);
    }
    public void Hit(Vector3 point)
    {
        destroyedWall.SetActive(true);

        Rigidbody[] pieces = destroyedWall.GetComponentsInChildren<Rigidbody>();

        foreach (var item in pieces)
        {
            Vector3 distance = item.transform.position - point;
            
            float power =  (damageRadius - distance.magnitude/damageRadius);
            Vector3 forward = direction.forward * power;

            item.AddForce(forward*forceForward,ForceMode.Impulse);
            

        }
        gameObject.SetActive(false);
    }
}
