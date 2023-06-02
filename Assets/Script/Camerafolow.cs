using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafolow : MonoBehaviour
{
    Transform player;
    public float minX, maxX;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("GameObject").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x;
            if (pos.x < minX)
            {
                pos.x = minX;
            }
            if (pos.x > maxX)
            {
                pos.x = maxX;
            }
            transform.position = pos;
        }
    }
}
