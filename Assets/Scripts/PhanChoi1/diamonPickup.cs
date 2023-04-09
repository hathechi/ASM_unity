using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class diamonPickup : MonoBehaviour
{
    public float diamonAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("NGUOICHOI"))
        {
            diChuyenNV diamon = other.gameObject.GetComponent<diChuyenNV>();
            diamon.addDiamon(diamonAmount);
            Destroy(gameObject);
        }
    }
}
