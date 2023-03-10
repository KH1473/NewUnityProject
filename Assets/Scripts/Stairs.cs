using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public GameObject stairs;
    public GameObject stairs_;
    GameObject switch_Base;　//Switch_Baseを入れる変数
    private Switch_Lever switch_Flag;　//Switch_Flagを参照する変数
    private bool is_Switch;

    private void Start()
    {
        //Switch_Baseの情報を取得
        switch_Base = GameObject.Find("Lever");
        //Switch_BaseのSwitch_Flagを取得
        switch_Flag = switch_Base.GetComponent<Switch_Lever>();
    }

    private void Update()
    {
        is_Switch = switch_Flag.is_Switch; //Switch_Flagからis_Switchを取得

        if (is_Switch)
        {
            stairs.transform.position = new Vector3(stairs.transform.position.x, stairs_.transform.position.y + 0.025f, stairs.transform.position.z);
        }
    }

}
