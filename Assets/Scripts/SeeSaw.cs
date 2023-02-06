using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private float walkSpeed = 1.5f;
    [SerializeField]
    private float jumpPower = 5.0f;

    [SerializeField]
    private float power = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            velocity = Vector3.zero;
            var input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if(input.magnitude>0.0f)
            {
                animator.SetFloat("Speed", input.magnitude);
                transform.LookAt(transform.position + input);
                velocity = transform.forward * walkSpeed;
            }
            else
            {
                animator.SetFloat("Speed", 0.0f);
            }

            if(Input.GetButtonDown("Jump")
                && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")
                && !animator.IsInTransition(0)
                )
            {
                animator.SetBool("Jump",true);
                velocity.y += jumpPower;
            }
        }

        velocity.y += Physics.gravity.y + Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    // 他のコライダと接触した時
    void OnControllerColliderHit(ControllerColliderHit col)
    {
        Debug.DrawLine(transform.position += Vector3.up * 0.1f, transform.position + Vector3.up * 0.1f + Vector3.down * 0.2f, Color.red);

        // rayPositionから下にレイを飛ばし、Blockレイヤーに当たっていたら力を加える
        if(Physics.Linecast(transform.position+Vector3.up*0.1f,transform.position+Vector3.up*0.1f+Vector3.down*0.2f,LayerMask.GetMask("Block")))
        {
            col.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Vector3.down * power, transform.position, ForceMode.Force);
        }
    }
}
