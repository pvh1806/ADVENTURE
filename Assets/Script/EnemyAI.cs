using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D enemyRb;
    Animator enemyAnimator;
    public GameObject enemy;
    bool FacingRinght = true;
    float timer = 5f;
    float nextFlip = 0f;
    bool canFlip = true;
    // Start is called before the first frame update
    void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + timer;
            Flip();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (FacingRinght & other.transform.position.x < transform.position.x)
            {
                Flip();
            }
            else if (!FacingRinght & other.transform.position.x > transform.position.x)
            {
                Flip();
            }
            canFlip = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!FacingRinght) enemyRb.AddForce(new Vector2(-1, 0) * 5f);
            else enemyRb.AddForce(new Vector2(1, 0) * 5f);
            enemyAnimator.SetBool("KtWalk", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            enemyRb.velocity = Vector2.zero;
            enemyAnimator.SetBool("KtWalk", false);
        }
    }
    void Flip()
    {
        if (!canFlip)
        {
            return;
        }
        FacingRinght = !FacingRinght;
        Vector3 theScale = enemy.transform.localScale;
        theScale.x = theScale.x * -1;
        enemy.transform.localScale = theScale;
    }
}
