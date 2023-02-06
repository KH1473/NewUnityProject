using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Ceil : MonoBehaviour
{
    public bool is_Switch; // ドアが開いたかどうかの変数
    // どちらかのIs TriggerがオンになっているCollider同士が接触している間常に呼び出し
    private void OnTriggerStay(Collider obj)
    {
        // 特定のボタンを押してかつis_Openがfalseの時is_Openをtrueにする
        if (obj.gameObject.CompareTag("Car") && !is_Switch)
        {
            is_Switch = true;
        }
    }
}
