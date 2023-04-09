using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phiKiem : MonoBehaviour
{
    // Start is called before the first frame update
    public float tocDoBan;
    public Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            rb.AddForce(new Vector2(-1, 0) * tocDoBan, ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(new Vector2(1, 0) * tocDoBan, ForceMode2D.Impulse);
        }
    }
    //Tạo hiệu ứng viên đạn dừng lại khi va chạm
    public void dungLaiKhiVaCham()
    {
        rb.velocity = new Vector2(0, 0);
    }
}
