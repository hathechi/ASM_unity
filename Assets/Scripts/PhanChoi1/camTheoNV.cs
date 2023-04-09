using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTheoNV : MonoBehaviour
{
    private Vector3 viTriCamera;
    private Transform nhanVat;
    [SerializeField]
    private float xMax, XMin;
    [SerializeField]
    private float yMax, yMin;
    void Start()
    {
        nhanVat = GameObject.FindWithTag("NGUOICHOI").transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (!nhanVat)
        {
            return;
        }
        camTheoNhanVat();
    }

    private void camTheoNhanVat()
    {
        viTriCamera = transform.position; //vi tri hien tai
        viTriCamera.x = nhanVat.position.x;
        viTriCamera.y = nhanVat.position.y;
        if (viTriCamera.x < XMin)
        {

            viTriCamera.x = XMin;
        }
        else if (viTriCamera.x > xMax)
        {
            viTriCamera.x = xMax;
        }


        if (viTriCamera.y < yMin)
        {

            viTriCamera.y = yMin;
        }
        else if (viTriCamera.y > yMax)
        {
            viTriCamera.y = yMax;
        }
        transform.position = viTriCamera;
    }
}
