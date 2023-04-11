using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomController : MonoBehaviour
{
    Rigidbody2D rb;
    public float speedHight;
    public float speedLow;
    public float bomAngle;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.AddForce(new Vector2(Random.Range(-bomAngle, bomAngle), Random.Range(speedLow, speedHight)), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
