using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        var screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, obj.transform.position); //�X�N���[�����W
        var viewportPos = Camera.main.WorldToViewportPoint(obj.transform.position);//�r���[�|�[�g���W
    }

    // Update is called once per frame
    void Update()
    {
    }
}
