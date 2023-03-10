using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject parentObj;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(parentObj != null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            this.gameObject.transform.SetParent(parentObj.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            this.gameObject.transform.SetParent(null);
        }
    }
}
