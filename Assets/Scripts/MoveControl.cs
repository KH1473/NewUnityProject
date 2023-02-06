using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControl : MonoBehaviour
{
    public Animator animator;

    private Rigidbody rb;
    private Vector3 moveForward;
    public float moveSpeed;

    public new GameObject camera;

    float inputHorizontal = 0;
    float inputVertical = 0;

    [SerializeField]
    private GameObject parentObj;

    [SerializeField]
    private GameObject parentObj_;

    private void FixedUpdate()
    {
        rb.AddForce(moveForward.normalized * moveSpeed,ForceMode.Impulse);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Assert(parentObj != null);
        Debug.Assert(parentObj_ != null);
    }

    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        moveForward = (cameraForward * inputVertical) + (Camera.main.transform.right * inputHorizontal);

        //moveForward = (cameraForward * inputVertical) + (camera.transform.right * inputHorizontal);
        //rb.velocity = moveForward * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(moveForward.z));

        if ((inputHorizontal != 0) || (inputVertical != 0))
        {
            transform.rotation = Quaternion.LookRotation(moveForward, transform.up);
        }

        if (rb.velocity.x > 0.3f)
        {
            rb.velocity = new Vector3(0.3f, rb.velocity.y, rb.velocity.z);
        }

        if(rb.velocity.x<-0.3f)
        {
            rb.velocity = new Vector3(-0.3f, rb.velocity.y, rb.velocity.z);
        }
        //if (rb.velocity.y > 0.3f)
        //{
        //    rb.velocity = new Vector3(rb.velocity.x, 0.3f, rb.velocity.z);
        //}

        if (rb.velocity.z > 0.3f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.3f);
        }
        if (rb.velocity.z < -0.3f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -0.3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.gameObject.transform.SetParent(parentObj.transform);
        }
        if (collision.gameObject.CompareTag("Bane"))
        {
            this.gameObject.transform.SetParent(parentObj_.transform);
        }
        if(collision.gameObject.CompareTag("Push"))
        {
            animator.SetBool("Push", true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.gameObject.transform.SetParent(null);
        }
        if (collision.gameObject.CompareTag("Bane"))
        {
            this.gameObject.transform.SetParent(null);
        }
        if (collision.gameObject.CompareTag("Push"))
        {
            animator.SetBool("Push", false);
        }

    }
}

