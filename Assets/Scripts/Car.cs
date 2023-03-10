using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject car;
    GameObject switch_Base;　//Switch_Baseを入れる変数
    private Switch_Car switch_Flag;　//Switch_Flagを参照する変数
    private bool is_Switch;

    public float speed = 1.0f;

    private void Start()
    {
        //Switch_Baseの情報を取得
        switch_Base = GameObject.Find("car_body");
        //Switch_BaseのSwitch_Flagを取得
        switch_Flag = switch_Base.GetComponent<Switch_Car>();
    }

    private void Update()
    {
        is_Switch = switch_Flag.is_Switch; //Switch_Flagからis_Switchを取得

        if (is_Switch)
        {
            car.transform.position += transform.forward * speed * 0.1f;
        }

        if (car.transform.position.z < -3.86f)
        {
            car.transform.position = new Vector3(car.transform.position.x, car.transform.position.y, -3.86f);
            speed = 0;
        }
    }

}
