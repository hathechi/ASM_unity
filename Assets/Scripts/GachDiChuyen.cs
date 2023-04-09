using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachDiChuyen : MonoBehaviour
{
    public float left;
    public float right;
    public float speed;
    bool isRight = false;




    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        if (x < left)
        {
            isRight = true;
        }
        if (x > right)
        {
            isRight = false;
        }
        if (isRight)
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }
    }
}
