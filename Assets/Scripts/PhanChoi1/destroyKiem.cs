using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyKiem : MonoBehaviour
{
    // Start is called before the first frame update
    public float thoiGianBienMat;
    void Start()
    {
        Destroy(gameObject, thoiGianBienMat);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
