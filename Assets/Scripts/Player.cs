using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator _animator;

    // キャラクターの操作状態を管理するフラグ
    public bool onGround = true;
    //private bool inJumping = false;

    public GameObject Camera;
    //移動スピード
    public float speed = 10.0f;

    //ジャンプパワー
    float jumpPower = 400f;

    //[SerializeField] private float gravityPower = -9.81f;

    //private Vector3 gravitationalForce;

    //public bool jumpMomentumCheck { get; private set; }

    //Rigidbodyを変数に入れる
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

        //スペースボタンでジャンプする
        //if (Input.GetKey(KeyCode.Space) && onGround)
        //{
        //    GetComponent<Rigidbody>().velocity = transform.up * jumpPower;
        //    //ジャンプ中は地面との接触判定をfalseにする
        //    onGround = false;
        //    inJumping = true;

        //    //前後キーを押しながらジャンプしたときは前後方向の力も発生
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

    //ジャンプ後、Planeに接触した時に接触判定をtrueに戻す
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
//    // キャラクターの操作状態を管理するフラグ
//    [SerializeField] public bool onGround = true;
//    [SerializeField] public bool inJumping = false;

//    //Rigidbodyを変数に入れる
//    Rigidbody rb;

//    //移動スピード
//    float speed = 6.0f;

//    //方向転換スピード
//    float angleSpeed = 200.0f;

//    //ジャンプパワー
//    public float jumpPower = 1.0f;

//    //移動の係数格納変数
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

//        // 移動の実行
//        if (!inJumping)//空中での移動を禁止
//        {
//            transform.position += transform.forward * v;
//        }

//        //スペースボタンでジャンプする
//        if (onGround)
//        {
//            if (Input.GetKey(KeyCode.Space))
//            {
//                //ジャンプさせるため上方向に力を発生
//                rb.AddForce(transform.up * jumpPower, ForceMode.Impulse);
//                //ジャンプ中は地面との接触判定をfalseにする
//                onGround = false;
//                inJumping = true;

//                //前後キーを押しながらジャンプしたときは前後方向の力も発生
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
//        //左右キーで方向変換
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
//        //方向転換動作の実行
//        transform.Rotate(Vector3.up * h);
//    }
//    //ジャンプ後、Planeに接触した時に接触判定をtrueに戻す
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
//    //Rigidbodyを変数に入れる
//    //Rigidbody rb;


//    //移動スピード
//    public float speed = 3.0f;
//    // 回転スピード
//    public float rotateSpeed = 3.0f;
//    //ジャンプ力
//    public float jumpPower = 5.0f;
//    // 重力
//    public float gravity = 10.0f;

//    private Vector3 moveDirection;
//    private Vector3 velocity;

//    private CharacterController controller;

//    //位置を取得
//    Vector3 playerPos;
//    //地面に接触している
//    bool Ground = true;
//    //int key = 0;


//    // Start is called before the first frame update
//    void Start()
//    {
//        // コンポーネントの取得
//        controller = GetComponent<CharacterController>();
//        ////Rigidbodyを取得
//        //rb = GetComponent<Rigidbody>();
//        ////現在より少し前の位置を保存
//        //playerPos = transform.position;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
//        velocity = moveDirection * speed;

//        if (controller.isGrounded)
//        {
//            // 回転
//            //transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

//            // キャラクターのローカル空間での方向
//            //moveDirection = transform.transform.forward * speed * Input.GetAxis("Vertical");

//            // ジャンプ
//            if (Input.GetButtonDown("Jump"))
//            {
//                moveDirection.y = jumpPower;
//            }
//        }
//        else
//        {
//            // 重力
//            moveDirection.y -= gravity * Time.deltaTime;
//        }

//        // SimpleMove関数で移動させる
//        controller.Move(velocity * Time.deltaTime);

//        //GetInputKey();
//        //Move();
//    }

//    //void GetInputKey()
//    //{
//    //    //A・Dキーで横移動
//    //    float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

//    //    //W・Sキーで前後移動
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
//    //            //JumpPowerの分だけ上方に力がかかる
//    //            rb.AddForce(transform.up * jumpPower);
//    //            Ground = false;
//    //        }
//    //    }

//    //    //現在の位置＋入力した数値の場所に移動する
//    //    rb.MovePosition(transform.position + new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime * speed));

//    //    //最新の位置から少し前の位置を引いて方向を割り出す
//    //    Vector3 direction = transform.position - playerPos;

//    //    //移動距離が少しでもあった場合に方向転換
//    //    //if (direction.magnitude >= 0.01f)
//    //    //{
//    //    //    //directionのX軸とZ軸の方向を向かせる
//    //    //    transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
//    //    //}
//    //    //else
//    //    //{
//    //    //    key = 0;
//    //    //}

//    //    playerPos = transform.position;
//    //}

//    //ジャンプ後、Planeに接触した時に接触判定をtrueに戻す
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
//        //斜め移動と縦横の移動を同じ速度にするためにVector3をNormalize()する。
//        moving = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
//        moving.Normalize();
//        moving = moving * speed;
//    }

//    public void RotateToMovingDirection()
//    {
//        Vector3 differenceDis = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(latestPos.x, 0, latestPos.z);
//        latestPos = transform.position;
//        //移動してなくても回転してしまうので、一定の距離以上移動したら回転させる
//        if (Mathf.Abs(differenceDis.x) > 0.001f || Mathf.Abs(differenceDis.z) > 0.001f)
//        {
//            Quaternion rot = Quaternion.LookRotation(differenceDis);
//            rot = Quaternion.Slerp(rb.transform.rotation, rot, 0.1f);
//            this.transform.rotation = rot;
//            //アニメーションを追加する場合
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