using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartPickup : MonoBehaviour
{

    public float heartAmount;

    private void Start()
    {


    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NGUOICHOI"))
        {
            mauNhanVat heartNV = other.gameObject.GetComponent<mauNhanVat>();
            heartNV.addHeart(heartAmount);
            Destroy(gameObject);
        }
    }
}
