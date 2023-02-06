using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player;
    public float rotatespeed = 5.0f; //��]���x

    private Vector3 offset; //�v���C���[�Ƃ̋���

    // Start is called before the first frame update
    void Start()
    {
        offset = Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();   //�J������]
        Move();     //�ǔ�
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
