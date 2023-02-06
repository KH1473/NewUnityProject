using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Bane : MonoBehaviour
{
    public bool is_Switch;
    //public KeyCode keyCode; // どのキーを入力するかの変数
    public GameObject bane;
    public GameObject bane_head;

    // どちらかのIs TriggerがオンになっているCollider同士が接触している間常に呼び出し
    private void OnTriggerStay(Collider obj)
    {
        // 特定のボタンを押してかつis_Openがfalseの時is_Openをtrueにする
        if (Input.GetMouseButtonDown(0) && !is_Switch)
        {
            is_Switch = true;
            bane.transform.localScale = new Vector3(bane.transform.localScale.x, bane.transform.localScale.y * 5.0f, bane.transform.localScale.z);
            bane_head.transform.position = new Vector3(bane_head.transform.position.x, 0.874f, bane_head.transform.position.z);
        }
    }
}
