using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Bane : MonoBehaviour
{
    public bool is_Switch;
    //public KeyCode keyCode; // �ǂ̃L�[����͂��邩�̕ϐ�
    public GameObject bane;
    public GameObject bane_head;

    // �ǂ��炩��Is Trigger���I���ɂȂ��Ă���Collider���m���ڐG���Ă���ԏ�ɌĂяo��
    private void OnTriggerStay(Collider obj)
    {
        // ����̃{�^���������Ă���is_Open��false�̎�is_Open��true�ɂ���
        if (Input.GetMouseButtonDown(0) && !is_Switch)
        {
            is_Switch = true;
            bane.transform.localScale = new Vector3(bane.transform.localScale.x, bane.transform.localScale.y * 5.0f, bane.transform.localScale.z);
            bane_head.transform.position = new Vector3(bane_head.transform.position.x, 0.874f, bane_head.transform.position.z);
        }
    }
}
