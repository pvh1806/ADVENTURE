using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rangcua : MonoBehaviour
{
    // Start is called before the first frame update
    int direction = 1;
    Vector2 vitribandau;
    // Start is called before the first frame update
    void Start()
    {
        vitribandau = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y - vitribandau.y >= 5)
            direction *= -1;
        else if (transform.position.y - vitribandau.y <= -5)
            direction *= -1;
        transform.Translate(Vector2.up * direction * SetLevel.speed * Time.deltaTime);
    }
}
