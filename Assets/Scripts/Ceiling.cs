using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    public GameObject ceiling;
    GameObject switch_Base;　//Switch_Baseを入れる変数
    private Switch_Ceil switch_Flag;　//Switch_Flagを参照する変数
    private bool is_Switch;

    private void Start()
    {
        //Switch_Baseの情報を取得
        switch_Base = GameObject.Find("Cube");
        //Switch_BaseのSwitch_Flagを取得
        switch_Flag = switch_Base.GetComponent<Switch_Ceil>();
    }

    private void Update()
    {
        is_Switch = switch_Flag.is_Switch; //Switch_Flagからis_Switchを取得

        if (is_Switch)
        {
            //ceiling.transform.position += transform.forward * speed * 0.05f;
            ceiling.GetComponent<Rotate>().enabled = true;
        }
    }
}
