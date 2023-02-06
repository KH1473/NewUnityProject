using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    public float pushPower = 2.0f;
    public GameObject cubeA;
    public GameObject cubeB;
    public GameObject push;

    // Start is called before the first frame update
    private void Start()
    {
        push.SetActive(false);
    }
    
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    void OnCollisionEnter(Collision hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;


        //void OnCollisionExit(Collision collision)
        //{
        //    // もし接触から離れた相手オブジェクトの名前が"ObjCube"ならば
        //    if (collision.gameObject.name == "ObjCube")
        //    {
        //        rb.isKinematic = true;
        //    }
        //}

        if (rb.gameObject.tag == "Push")
        {
            push.SetActive(true);
        }
        else
        {
            push.SetActive(false);
        }

        if (Input.GetButton("Push"))
        {
            if (rb == null)
            {
                return;
            }

            if (cubeA.transform.position.y < -0.3f)
            {
                return;
            }

            if(rb.isKinematic)
            {
                rb.isKinematic = false;
            }

            Vector3 pushDir = new Vector3(cubeA.transform.position.x, 0, cubeA.transform.position.z);

            rb.velocity = pushDir * pushPower;

        }
        else
        {
            rb.isKinematic = true;
        }
    }
}
