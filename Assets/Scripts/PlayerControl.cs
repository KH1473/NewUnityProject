using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public new GameObject camera;
    public float moveSpeed = 10;
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = Vector3.Scale(camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = (cameraForward * z) + (camera.transform.right * x);
        rig.velocity = moveForward * moveSpeed;

        if ((x != 0) || (z != 0))
        {
            transform.rotation = Quaternion.LookRotation(moveForward, transform.up);
        }
    }
}
