//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class JumpPlayer : MonoBehaviour
//{
//    public float jumpPower;
//    private Rigidbody rb;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if(Input.GetKey(KeyCode.Space))
//        {
//            rb.velocity = Vector3.up * jumpPower;
//        }
//    }
//}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    public float jumpPower;
    private Rigidbody rb;
    public bool isJumping = false;

    //private float gravityPower = -1.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }

        //if (isJumping)
        //{
        //    rb.velocity += Vector3.up * gravityPower;
        //}

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (collision.gameObject.CompareTag("Block"))
        {
            isJumping = false;
        }
    }
}
