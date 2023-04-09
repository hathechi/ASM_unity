using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Khi nhân vật cách enemy một khoảng cách thì enemy di chuyển theo
    Rigidbody2D rb;
    public GameObject player;
    float khoangCach;
    public float speed;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        khoangCach = Vector2.Distance(player.transform.position, transform.position); // Xác định khoảng cách
        Vector2 direct = player.transform.position = transform.position; // Xác định hướng đến
        if (khoangCach < 10)
        {
            //Chạy đến với tốc độ ..
            transform.position = Vector2.MoveTowards(transform.position, direct, Time.deltaTime * speed);
        }
    }
}
