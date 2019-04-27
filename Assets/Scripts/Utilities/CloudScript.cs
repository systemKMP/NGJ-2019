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
        if (transform.localPosition.x > rightBorder)
        {
            transform.localPosition = new Vector3(leftBorder, transform.localPosition.y, transform.localPosition.z);
        }
        else if (transform.localPosition.x < leftBorder)
        {
            transform.localPosition = new Vector3(rightBorder, transform.localPosition.y, transform.localPosition.z);
        }

        transform.Translate(transform.InverseTransformDirection(Vector3.right * Time.deltaTime * cloudSpeed));
    }
}