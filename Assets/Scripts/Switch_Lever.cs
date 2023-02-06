using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Lever : MonoBehaviour
{
    public bool is_Switch; 
    //public KeyCode keyCode; // どのキーを入力するかの変数
    public GameObject lever;

    // どちらかのIs TriggerがオンになっているCollider同士が接触している間常に呼び出し
    private void OnTriggerStay(Collider obj)
    {
        // 特定のボタンを押してかつis_Openがfalseの時is_Openをtrueにする
        if (Input.GetMouseButtonDown(0) && !is_Switch)
        {
            is_Switch = true;
            lever.transform.position += transform.forward * -0.02f;
        }
    }
}
