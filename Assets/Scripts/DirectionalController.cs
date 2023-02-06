using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalController : MonoBehaviour
{
    public GameObject image;
    public GameObject canvas;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player_animation_all (5)");
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float dis = Vector3.Distance(canvas.transform.position, player.transform.position);

        if (dis < 0.5f)
        {
            transform.LookAt(player.transform);
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
    }
}
