using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vaChamKhiBanDan : MonoBehaviour
{
    phiKiem phiKiem;
    public GameObject hieuUngNo;

    public float satThuongCuaMotLanBan;

    // Start is called before the first frame update
    void Awake()
    {
        phiKiem = GetComponentInParent<phiKiem>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "QUAIVAT")
        {
            phiKiem.dungLaiKhiVaCham();
            Instantiate(hieuUngNo, transform.position, transform.rotation);
            Destroy(gameObject);

            thanhMauQV hearth = other.gameObject.GetComponent<thanhMauQV>();
            hearth.addDamge(satThuongCuaMotLanBan);
        }


    }



}
