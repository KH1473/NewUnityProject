using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    public GameObject ceiling;
    GameObject switch_Base;�@//Switch_Base������ϐ�
    private Switch_Ceil switch_Flag;�@//Switch_Flag���Q�Ƃ���ϐ�
    private bool is_Switch;

    private void Start()
    {
        //Switch_Base�̏����擾
        switch_Base = GameObject.Find("Cube");
        //Switch_Base��Switch_Flag���擾
        switch_Flag = switch_Base.GetComponent<Switch_Ceil>();
    }

    private void Update()
    {
        is_Switch = switch_Flag.is_Switch; //Switch_Flag����is_Switch���擾

        if (is_Switch)
        {
            //ceiling.transform.position += transform.forward * speed * 0.05f;
            ceiling.GetComponent<Rotate>().enabled = true;
        }
    }
}
