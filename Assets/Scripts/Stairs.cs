using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public GameObject stairs;
    public GameObject stairs_;
    GameObject switch_Base;�@//Switch_Base������ϐ�
    private Switch_Lever switch_Flag;�@//Switch_Flag���Q�Ƃ���ϐ�
    private bool is_Switch;

    private void Start()
    {
        //Switch_Base�̏����擾
        switch_Base = GameObject.Find("Lever");
        //Switch_Base��Switch_Flag���擾
        switch_Flag = switch_Base.GetComponent<Switch_Lever>();
    }

    private void Update()
    {
        is_Switch = switch_Flag.is_Switch; //Switch_Flag����is_Switch���擾

        if (is_Switch)
        {
            stairs.transform.position = new Vector3(stairs.transform.position.x, stairs_.transform.position.y + 0.025f, stairs.transform.position.z);
        }
    }

}
