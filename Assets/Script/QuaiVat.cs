using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaiVat : MonoBehaviour
{
    int direction = 1;
    Vector2 vitribandau;
    SpriteRenderer sp;
    bool FacingRinght = true;
    // Start is called before the first frame update
    void Start()
    {
        vitribandau = transform.position;
        sp = GetComponent<SpriteRenderer>();
        //sp.flipX = true;
    }
  
       
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x - vitribandau.x >= 4)
        {
            direction *= -1; 
        }
        else if (transform.position.x - vitribandau.x <= -4)
            direction *= -1;         
            transform.Translate(Vector2.left * direction * SetLevel.speed * Time.deltaTime);

        if (transform.position.x - vitribandau.x >=4 & !FacingRinght)
        {
            Flip();
        }
        else if (transform.position.x - vitribandau.x <= -4 & FacingRinght)
        {
            Flip();
        }
    }
    void Flip()
    {
        FacingRinght =!FacingRinght;
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    }
}
