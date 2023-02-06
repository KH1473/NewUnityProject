using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    public float rotatespeed = 5.0f; //回転速度

    private Vector3 offset; //プレイヤーとの距離

    // Start is called before the first frame update
    void Start()
    {
        offset = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();   //カメラ回転
        Move();     //追尾
    }

    private void Move()
    {
        transform.position += Player.transform.position - offset;
        offset = Player.transform.position;
    }

    private void Rotate()
    {
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotatespeed, Input.GetAxis("Mouse Y") * -rotatespeed, 0);

        transform.RotateAround(Player.transform.position, Vector3.up, angle.x);
        transform.RotateAround(Player.transform.position, transform.right, angle.y);
    }
}
