using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator _animator;

    // �L�����N�^�[�̑����Ԃ��Ǘ�����t���O
    public bool onGround = true;
    //private bool inJumping = false;

    public GameObject Camera;
    //�ړ��X�s�[�h
    public float speed = 10.0f;

    //�W�����v�p���[
    float jumpPower = 400f;

    //[SerializeField] private float gravityPower = -9.81f;

    //private Vector3 gravitationalForce;

    //public bool jumpMomentumCheck { get; private set; }

    //Rigidbody��ϐ��ɓ����
    private Rigidbody rb;

    [SerializeField]
    private GameObject parentObj;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Assert(parentObj != null);
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = Vector3.Scale(Camera.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveForward = (cameraForward * z) + (Camera.transform.right * x);
        rb.velocity = moveForward * speed;

        _animator.SetFloat("Speed", Mathf.Abs(moveForward.z));

        if ((x != 0) || (z != 0))
        {
            transform.rotation = Quaternion.LookRotation(moveForward, transform.up);
        }

        if(Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            _animator.SetBool("InJump", true);
            rb.AddForce(new Vector3(0, jumpPower, 0));
            onGround = false;
        }

        //verticalSpeed -= gravity * Time.deltaTime;
        //rb.AddForce(new Vector3(0, verticalSpeed, 0),ForceMode.Force);

        //jumpMomentumCheck = jumpMomentumCheck && Input.GetKey(KeyCode.Space) && !onGround;

        //�X�y�[�X�{�^���ŃW�����v����
        //if (Input.GetKey(KeyCode.Space) && onGround)
        //{
        //    GetComponent<Rigidbody>().velocity = transform.up * jumpPower;
        //    //�W�����v���͒n�ʂƂ̐ڐG�����false�ɂ���
        //    onGround = false;
        //    inJumping = true;

        //    //�O��L�[�������Ȃ���W�����v�����Ƃ��͑O������̗͂�����
        //    if (Input.GetKey(KeyCode.W))
        //    {
        //        rb.AddForce(transform.forward * 3.0f, ForceMode.Impulse);
        //    }
        //    else if (Input.GetKey(KeyCode.S))
        //    {
        //        rb.AddForce(transform.forward * -2.0f, ForceMode.Impulse);
        //    }
        //}
        

        //if (onGround)
        //{
        //    gravitationalForce.y = gravityPower * Time.deltaTime;
        //    jumpMomentumCheck = true;
        //}
        //else
        //{
        //    if(!jumpMomentumCheck && gravitationalForce.y>0)
        //    {
        //        gravitationalForce.y = 0;
        //    }
        //    else
        //    {
        //        gravitationalForce.y += gravityPower * Time.deltaTime;
        //    }
        //}

        //if(inJumping)
        //{
        //    GetComponent<Rigidbody>().velocity = transform.up * gravityPower;
        //}

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.gameObject.transform.SetParent(parentObj.transform);
        }

        if(collision.gameObject.CompareTag("Push"))
        {
            _animator.SetBool("Push", true);
        }

        onGround = true;
        _animator.SetBool("InJump", false);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            this.gameObject.transform.SetParent(null);
        }

        if (collision.gameObject.CompareTag("Push"))
        {
            _animator.SetBool("Push", false);
        }
    }

    //�W�����v��APlane�ɐڐG�������ɐڐG�����true�ɖ߂�
    //private void OnCollisionEnter(Collision other)
    //{
    //    if (inJumping == true)
    //    {
    //        if (other.gameObject.CompareTag("Ground"))
    //        {
    //            onGround = true;
    //            inJumping = false;
    //        }
    //        if (other.gameObject.CompareTag("Push"))
    //        {
    //            onGround = true;
    //            inJumping = false;
    //        }
    //        if (other.gameObject.CompareTag("Block"))
    //        {
    //            onGround = true;
    //            inJumping = false;
    //        }
    //    }
    //}
}

//public class Player : MonoBehaviour
//{
//    // �L�����N�^�[�̑����Ԃ��Ǘ�����t���O
//    [SerializeField] public bool onGround = true;
//    [SerializeField] public bool inJumping = false;

//    //Rigidbody��ϐ��ɓ����
//    Rigidbody rb;

//    //�ړ��X�s�[�h
//    float speed = 6.0f;

//    //�����]���X�s�[�h
//    float angleSpeed = 200.0f;

//    //�W�����v�p���[
//    public float jumpPower = 1.0f;

//    //�ړ��̌W���i�[�ϐ�
//    float v;
//    float h;

//    private void Start()
//    {
//        rb = this.GetComponent<Rigidbody>();
//        rb.constraints = RigidbodyConstraints.FreezeRotation;
//    }

//    void Update()
//    {
//        if (Input.GetKey(KeyCode.W))
//        {
//            v = Time.deltaTime * speed;
//        }
//        else if (Input.GetKey(KeyCode.S))
//        {
//            v = -Time.deltaTime * speed;
//        }
//        else
//        {
//            v = 0;
//        }

//        // �ړ��̎��s
//        if (!inJumping)//�󒆂ł̈ړ����֎~
//        {
//            transform.position += transform.forward * v;
//        }

//        //�X�y�[�X�{�^���ŃW�����v����
//        if (onGround)
//        {
//            if (Input.GetKey(KeyCode.Space))
//            {
//                //�W�����v�����邽�ߏ�����ɗ͂𔭐�
//                rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
//                //�W�����v���͒n�ʂƂ̐ڐG�����false�ɂ���
//                onGround = false;
//                inJumping = true;

//                //�O��L�[�������Ȃ���W�����v�����Ƃ��͑O������̗͂�����
//                if (Input.GetKey(KeyCode.W))
//                {
//                    rb.AddForce(transform.forward * 3.0f, ForceMode.Impulse);
//                }
//                else if (Input.GetKey(KeyCode.S))
//                {
//                    rb.AddForce(transform.forward * -2.0f, ForceMode.Impulse);
//                }
//            }
//        }
//        //���E�L�[�ŕ����ϊ�
//        if (Input.GetKey(KeyCode.D))
//        {
//            h = Time.deltaTime * angleSpeed;
//        }
//        else if (Input.GetKey(KeyCode.A))
//        {
//            h = -Time.deltaTime * angleSpeed;
//        }
//        else
//        {
//            h = 0;
//        }
//        //�����]������̎��s
//        transform.Rotate(Vector3.up * h);
//    }
//    //�W�����v��APlane�ɐڐG�������ɐڐG�����true�ɖ߂�
//    void OnCollisionEnter(Collision col)
//    {
//        if (col.gameObject.tag == "Ground")
//        {
//            onGround = true;
//            inJumping = false;
//        }
//        if (col.gameObject.tag == "Push")
//        {
//            onGround = true;
//            inJumping = false;
//        }
//    }
//}

//[RequireComponent(typeof(CharacterController))]
//public class Player : MonoBehaviour
//{
//    //Rigidbody��ϐ��ɓ����
//    //Rigidbody rb;


//    //�ړ��X�s�[�h
//    public float speed = 3.0f;
//    // ��]�X�s�[�h
//    public float rotateSpeed = 3.0f;
//    //�W�����v��
//    public float jumpPower = 5.0f;
//    // �d��
//    public float gravity = 10.0f;

//    private Vector3 moveDirection;
//    private Vector3 velocity;

//    private CharacterController controller;

//    //�ʒu���擾
//    Vector3 playerPos;
//    //�n�ʂɐڐG���Ă���
//    bool Ground = true;
//    //int key = 0;


//    // Start is called before the first frame update
//    void Start()
//    {
//        // �R���|�[�l���g�̎擾
//        controller = GetComponent<CharacterController>();
//        ////Rigidbody���擾
//        //rb = GetComponent<Rigidbody>();
//        ////���݂�菭���O�̈ʒu��ۑ�
//        //playerPos = transform.position;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//        velocity = moveDirection * speed;

//        if (controller.isGrounded)
//        {
//            // ��]
//            //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

//            // �L�����N�^�[�̃��[�J����Ԃł̕���
//            //moveDirection = transform.transform.forward * speed * Input.GetAxis("Vertical");

//            // �W�����v
//            if (Input.GetButtonDown("Jump"))
//            {
//                moveDirection.y = jumpPower;
//            }
//        }
//        else
//        {
//            // �d��
//            moveDirection.y -= gravity * Time.deltaTime;
//        }

//        // SimpleMove�֐��ňړ�������
//        controller.Move(velocity * Time.deltaTime);

//        //GetInputKey();
//        //Move();
//    }

//    //void GetInputKey()
//    //{
//    //    //A�ED�L�[�ŉ��ړ�
//    //    float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

//    //    //W�ES�L�[�őO��ړ�
//    //    float z = Input.GetAxisRaw("Vertical") * Time.deltaTime * speed;

//    //    if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow))
//    //    {
//    //        key = 1;
//    //    }

//    //    if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow))
//    //    {
//    //        key = -1;
//    //    }

//    //}

//    //void Move()
//    //{
//    //    if(Ground)
//    //    {
//    //        if(Input.GetButton("Jump"))
//    //        {
//    //            //JumpPower�̕���������ɗ͂�������
//    //            rb.AddForce(transform.up * jumpPower);
//    //            Ground = false;
//    //        }
//    //    }

//    //    //���݂̈ʒu�{���͂������l�̏ꏊ�Ɉړ�����
//    //    rb.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed));

//    //    //�ŐV�̈ʒu���班���O�̈ʒu�������ĕ���������o��
//    //    Vector3 direction = transform.position - playerPos;

//    //    //�ړ������������ł��������ꍇ�ɕ����]��
//    //    //if (direction.magnitude >= 0.01f)
//    //    //{
//    //    //    //direction��X����Z���̕�������������
//    //    //    transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//    //    //}
//    //    //else
//    //    //{
//    //    //    key = 0;
//    //    //}

//    //    playerPos = transform.position;
//    //}

//    //�W�����v��APlane�ɐڐG�������ɐڐG�����true�ɖ߂�
//    void OnTriggerEnter(Collider col)
//    {
//        if (col.gameObject.tag == "Ground")
//        {
//            if (!Ground)
//                Ground = true;
//        }
//    }
//}

//public class Player : MonoBehaviour
//{
//    public Rigidbody rb;
//    public Vector3 moving, latestPos;
//    public float speed;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        speed = 5;
//    }

//    void Update()
//    {
//        MovementControll();
//        Movement();
//    }

//    void FixedUpdate()
//    {
//        RotateToMovingDirection();
//    }
//    void MovementControll()
//    {
//        //�΂߈ړ��Əc���̈ړ��𓯂����x�ɂ��邽�߂�Vector3��Normalize()����B
//        moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        moving.Normalize();
//        moving = moving * speed;
//    }

//    public void RotateToMovingDirection()
//    {
//        Vector3 differenceDis = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(latestPos.x, 0, latestPos.z);
//        latestPos = transform.position;
//        //�ړ����ĂȂ��Ă���]���Ă��܂��̂ŁA���̋����ȏ�ړ��������]������
//        if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
//        {
//            Quaternion rot = Quaternion.LookRotation(differenceDis);
//            rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.1f);
//            this.transform.rotation = rot;
//            //�A�j���[�V������ǉ�����ꍇ
//            //animator.SetBool("run", true);
//        }
//        else
//        {
//            //animator.SetBool("run", false);
//        }
//    }

//    void Movement()
//    {
//        rb.velocity = moving;
//    }
//}