using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject car;
    GameObject switch_Base;@//Switch_Base‚ğ“ü‚ê‚é•Ï”
    private Switch_Car switch_Flag;@//Switch_Flag‚ğQÆ‚·‚é•Ï”
    private bool is_Switch;

    public float speed = 1.0f;

    private void Start()
    {
        //Switch_Base‚Ìî•ñ‚ğæ“¾
        switch_Base = GameObject.Find("car_body");
        //Switch_Base‚ÌSwitch_Flag‚ğæ“¾
        switch_Flag = switch_Base.GetComponent<Switch_Car>();
    }

    private void Update()
    {
        is_Switch = switch_Flag.is_Switch; //Switch_Flag‚©‚çis_Switch‚ğæ“¾

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
