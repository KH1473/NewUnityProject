using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 6.0f;

    //Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, rotateSpeed, 0));
        //rb.angularVelocity = new Vector3(0, rotateSpeed, 0);
    }
}
