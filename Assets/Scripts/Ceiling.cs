using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour
{
    public GameObject ceiling;
    GameObject switch_Base;@//Switch_Base‚ğ“ü‚ê‚é•Ï”
    private Switch_Ceil switch_Flag;@//Switch_Flag‚ğQÆ‚·‚é•Ï”
    private bool is_Switch;

    private void Start()
    {
        //Switch_Base‚Ìî•ñ‚ğæ“¾
        switch_Base = GameObject.Find("Cube");
        //Switch_Base‚ÌSwitch_Flag‚ğæ“¾
        switch_Flag = switch_Base.GetComponent<Switch_Ceil>();
    }

    private void Update()
    {
        is_Switch = switch_Flag.is_Switch; //Switch_Flag‚©‚çis_Switch‚ğæ“¾

        if (is_Switch)
        {
            //ceiling.transform.position += transform.forward * speed * 0.05f;
            ceiling.GetComponent<Rotate>().enabled = true;
        }
    }
}
