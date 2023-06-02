using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    public float speed = 4f;
    public float jump = 8f;
    Rigidbody2D rb;
    Animator ani;
    bool ground;
    bool AnimaitionJump;
    bool FacingRinght = true;
    public AudioSource audioJump;
    //Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    //Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        ani.SetFloat("move", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        if (move > 0 & !FacingRinght)
        {
            Flip();
        }
        else if (move < 0 & FacingRinght)
        {
            Flip();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (ground == true)
            {
                audioJump.Play();
                rb.velocity = new Vector2(rb.velocity.x, jump);
                AnimaitionJump = true;
                ani.SetBool("KtJump", AnimaitionJump);
                ground = false;
            }
        }
    }
    void Flip()
    {
        FacingRinght = !FacingRinght;
        Vector3 theScale = transform.localScale;
        theScale.x = theScale.x * -1;
        transform.localScale = theScale;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Map1")
        {
            ground = true;
            AnimaitionJump = false;
            ani.SetBool("KtJump", AnimaitionJump);
        }
    }
}
