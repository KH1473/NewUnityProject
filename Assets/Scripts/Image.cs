using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        var screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, obj.transform.position); //スクリーン座標
        var viewportPos = Camera.main.WorldToViewportPoint(obj.transform.position);//ビューポート座標
    }

    // Update is called once per frame
    void Update()
    {
    }
}
