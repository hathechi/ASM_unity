using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuayDauEnemy : MonoBehaviour
{
    public float tocdoQV;
    private Rigidbody2D rb;
    private bool checkChamTuong = false;
    public float x, y, z;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += new Vector3(tocdoQV, 0, 0) * Time.deltaTime;
    }
    // private void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("MATDAT"))
    //     {
    //         checkChamTuong = !checkChamTuong;
    //         if (checkChamTuong)
    //         {
    //             tocdoQV = tocdoQV * -1;
    //             // transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
    //             transform.localScale = new Vector3(-x, y, z);

    //         }
    //         else
    //         {
    //             tocdoQV = tocdoQV * -1;
    //             // transform.localScale = new Vector3(0.5f, 0.5f, 1f);
    //             transform.localScale = new Vector3(x, y, z);

    //         }
    //     }
    // }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("MATDAT"))
        {
            checkChamTuong = !checkChamTuong;
            if (checkChamTuong)
            {
                tocdoQV = tocdoQV * -1;
                transform.localScale = new Vector3(-x, y, z);
            }
            else
            {
                tocdoQV = tocdoQV * -1;
                transform.localScale = new Vector3(x, y, z);
            }
        }
    }
}
