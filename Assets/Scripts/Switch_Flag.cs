using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Flag : MonoBehaviour
{
    public bool is_Switch; // �h�A���J�������ǂ����̕ϐ�
    public KeyCode keyCode; // �ǂ̃L�[����͂��邩�̕ϐ�
    // �ǂ��炩��Is Trigger���I���ɂȂ��Ă���Collider���m���ڐG���Ă���ԏ�ɌĂяo��
    private void OnTriggerStay(Collider obj)
    {
        // ����̃{�^���������Ă���is_Open��false�̎�is_Open��true�ɂ���
        if (/*Input.GetKey(keyCode) && */!is_Switch)
        {
            is_Switch = true;
        }
    }
}
