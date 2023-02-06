using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Lever : MonoBehaviour
{
    public bool is_Switch; 
    //public KeyCode keyCode; // �ǂ̃L�[����͂��邩�̕ϐ�
    public GameObject lever;

    // �ǂ��炩��Is Trigger���I���ɂȂ��Ă���Collider���m���ڐG���Ă���ԏ�ɌĂяo��
    private void OnTriggerStay(Collider obj)
    {
        // ����̃{�^���������Ă���is_Open��false�̎�is_Open��true�ɂ���
        if (Input.GetMouseButtonDown(0) && !is_Switch)
        {
            is_Switch = true;
            lever.transform.position += transform.forward * -0.02f;
        }
    }
}
