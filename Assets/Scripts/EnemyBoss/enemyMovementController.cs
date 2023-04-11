using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D rb;
    Animator enemyAnim;
    //Các biến giúp enemy quay mặt
    public GameObject enemyGraphic;
    bool faceRight = true;
    float facingTime = 5f;
    bool canFlip = true;
    float nextFlip = 0f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NGUOICHOI"))
        {
            if (faceRight && other.transform.position.x < transform.position.x)
            {
                flip();
            }
            else if (!faceRight && other.transform.position.x > transform.position.x)
            {
                flip();
            }
            canFlip = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("NGUOICHOI"))
        {
            if (!faceRight)
            {
                rb.AddForce(new Vector3(-1, 0, 1) * enemySpeed);
            }
            else
            {
                rb.AddForce(new Vector3(1, 0, 1) * enemySpeed);
            }
            enemyAnim.SetBool("attack", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NGUOICHOI"))
        {
            canFlip = true;
            rb.velocity = new Vector3(0, 0, 0);
            enemyAnim.SetBool("attack", false);
        }
    }
    void flip()
    {
        if (!canFlip)
        {
            return;
        }
        faceRight = !faceRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
}
