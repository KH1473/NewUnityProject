using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Car : MonoBehaviour
{
    public bool is_Switch; // �h�A���J�������ǂ����̕ϐ�
    // �ǂ��炩��Is Trigger���I���ɂȂ��Ă���Collider���m���ڐG���Ă���ԏ�ɌĂяo��
    private void OnTriggerStay(Collider obj)
    {
        // ����̃{�^���������Ă���is_Open��false�̎�is_Open��true�ɂ���
        if (obj.gameObject.CompareTag("Push") && !is_Switch)
        {
            is_Switch = true;
        }
    }
}
