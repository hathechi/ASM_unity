using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoShootEnemy : MonoBehaviour
{
    public GameObject theBom;
    public Transform shootForm;
    public float shootTime;
    float nextShoot = 0f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("NGUOICHOI") && Time.time > nextShoot)
        {
            nextShoot = Time.time + shootTime;
            Instantiate(theBom, shootForm.position, Quaternion.identity);
        }
    }
}
