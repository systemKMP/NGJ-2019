using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    [SerializeField]
    float cloudSpeed = 1;
    [SerializeField]
    float rightBorder = 8;
    [SerializeField]
    float leftBorder = -9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.z > rightBorder)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, leftBorder);
        }
        else if (transform.localPosition.z < leftBorder)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, rightBorder);
        }

        transform.Translate(transform.InverseTransformDirection(Vector3.forward * Time.deltaTime * cloudSpeed));
    }
}