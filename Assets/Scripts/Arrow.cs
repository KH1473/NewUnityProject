using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //public GameObject bookShelf;
    public GameObject arrow;
    GameObject switch_Base;@//Switch_Base‚ğ“ü‚ê‚é•Ï”
    private Switch_Flag switch_Flag;@//Switch_Flag‚ğQÆ‚·‚é•Ï”
    private bool is_Switch;

    public float speed = 6.0f;
    public float speed_ = 6.0f;

    private void Start()
    {
        //Switch_Base‚Ìî•ñ‚ğæ“¾
        switch_Base = GameObject.Find("Cylinder_blue (2)");
        //Switch_Base‚ÌSwitch_Flag‚ğæ“¾
        switch_Flag = switch_Base.GetComponent<Switch_Flag>();
    }

    private void Update()
    {
        is_Switch = switch_Flag.is_Switch; //Switch_Flag‚©‚çis_Switch‚ğæ“¾

        if (is_Switch)
        {
            arrow.transform.position += transform.forward * speed;
        }

        if (arrow.transform.position.x >= 2.962f)
        {
            arrow.transform.position = new Vector3(2.962f, arrow.transform.position.y, arrow.transform.position.z);
            speed = 0;
            //bookShelf.transform.position += transform.right * speed_;
        }

        //if (bookShelf.transform.position.z > 0.53f)
        //{
        //    bookShelf.transform.position = new Vector3(bookShelf.transform.position.x, bookShelf.transform.position.y, 0.53f);
        //    arrow.SetActive(false);
        //}

    }

}
