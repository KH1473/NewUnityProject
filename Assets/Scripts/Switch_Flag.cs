using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Flag : MonoBehaviour
{
    public bool is_Switch; // ドアが開いたかどうかの変数
    public KeyCode keyCode; // どのキーを入力するかの変数
    // どちらかのIs TriggerがオンになっているCollider同士が接触している間常に呼び出し
    private void OnTriggerStay(Collider obj)
    {
        // 特定のボタンを押してかつis_Openがfalseの時is_Openをtrueにする
        if (/*Input.GetKey(keyCode) && */!is_Switch)
        {
            is_Switch = true;
        }
    }
}
