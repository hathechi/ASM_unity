using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachDiChuyen : MonoBehaviour
{
    public float left;
    public float right;
    public float speed;
    bool isRight = false;

    private Vector3 lastPos; // Vị trí trước đó của viên gạch
    private GameObject player; // Tham chiếu tới nhân vật
    bool vaCham = false;

    private void Start()
    {
        // Lấy tham chiếu tới nhân vật
        player = GameObject.FindWithTag("NGUOICHOI");
    }
    // Update is called once per frame
    void Update()
    {
        // Lưu trữ vị trí trước đó của viên gạch
        lastPos = transform.position;

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
            transform.position += new Vector3(Time.deltaTime * speed, 0, 0);
            // transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-Time.deltaTime * speed, 0, 0);

            // transform.Translate(-Time.deltaTime * speed, 0, 0);
        }

        if (vaCham)
        {
            diChuyenTheoGach(lastPos);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NGUOICHOI"))
        {
            vaCham = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NGUOICHOI"))
        {
            Debug.Log("Ra Khoi Gach");
            vaCham = false;
        }
    }
    void diChuyenTheoGach(Vector3 lastPos)
    {
        // Cập nhật vị trí của nhân vật sao cho nó di chuyển cùng với viên gạch
        player.transform.position += transform.position - lastPos;
    }
}
