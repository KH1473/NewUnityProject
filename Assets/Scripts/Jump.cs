using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jump : MonoBehaviour
{
    public Animator animator;

    private Rigidbody rb;//  Rigidbodyを使うための変数
    private bool Grounded;//  地面に着地しているか判定する変数
    public float Jumppower;//  ジャンプ力

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//  rbにRigidbodyの値を代入する
    }

    // Update is called once per frame
    void Update()
    {
        if (Grounded == true)//  もし、Groundedがtrueなら、
        {
            if (Input.GetKeyDown(KeyCode.Space))//  もし、スペースキーがおされたなら、  
            {
                animator.SetTrigger("Jump");
                Grounded = false;//  Groundedをfalseにする
                animator.SetBool("Grounded", false);
                rb.AddForce(Vector3.up * Jumppower, ForceMode.Impulse);//  上にJumpPower分力をかける
            }
        }

        if (rb.velocity.x > 0.3f)
        {
            rb.velocity = new Vector3(0.3f, rb.velocity.y, rb.velocity.z);
        }

        if (rb.velocity.z > 0.3f)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0.3f);
        }
    }

    void OnCollisionEnter(Collision other)//  地面に触れた時の処理
    {
        if (other.gameObject.tag == "Ground")//  もしGroundというタグがついたオブジェクトに触れたら、
        {
            Grounded = true;//  Groundedをtrueにする
            animator.SetBool("Grounded", true);
        }
    }
}