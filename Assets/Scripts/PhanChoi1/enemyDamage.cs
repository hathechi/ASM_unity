using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{

    public float damge;
    float rateDamge = 0.5f;
    float nextDamge = 0f;
    public float pushBackForce;

    public AudioSource sound_damage;
    void Start()
    {
        nextDamge = 0f;

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("NGUOICHOI") && nextDamge < Time.time)
        {

            Debug.Log("matmau");
            mauNhanVat hearthPlayer = other.gameObject.GetComponent<mauNhanVat>();
            hearthPlayer.addDamge(damge);
            nextDamge = rateDamge + Time.time;


            pushBackY(other.transform);
            pushBackX(other.transform);
        }
        if (other.gameObject.CompareTag("NGUOICHOI"))
        {
            sound_damage.Play();
        }
    }

    private void pushBackY(Transform pushObject)
    {
        Vector2 pushDrirectionY = new Vector2(0, (pushObject.position.y - transform.position.y)).normalized;
        // Vector2 pushDrirectionX = new Vector2((pushObject.position.x - transform.position.x), 0).normalized;
        pushDrirectionY = pushDrirectionY * pushBackForce;
        // pushDrirectionX = pushDrirectionX * pushBackForce;
        Rigidbody2D rb = pushObject.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(pushDrirectionY, ForceMode2D.Impulse);
        // rb.AddForce(pushDrirectionX, ForceMode2D.Impulse);
    }
    private void pushBackX(Transform pushObject)
    {
        Vector2 pushDrirectionX = new Vector2((pushObject.position.x - transform.position.x), 0).normalized;
        pushDrirectionX = pushDrirectionX * pushBackForce;
        Rigidbody2D rb = pushObject.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(pushDrirectionX, ForceMode2D.Impulse);
    }


}
