using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xuatHienQV : MonoBehaviour
{
    //mảng gán quái vật 
    [SerializeField]
    private GameObject[] taoQuaiVat;
    // tạo biến chứa vị trí xuất hiện của quái vật
    [SerializeField]

    private Transform vtXuatHien1;
    // private Transform vtXuatHien1, vtXuatHien2;
    // tạo biến sinh ra quái
    private GameObject hienQV;
    private int ranDomQV;
    private int ranDomViTri;
    public float thoiGianXuatHien;
    public float soLanXuatHien;

    void Start()
    {
        StartCoroutine(XuatHienQuaiVat());
    }

    IEnumerator XuatHienQuaiVat()
    {
        for (int i = 0; i < soLanXuatHien; i++)
        {
            yield return new WaitForSeconds(thoiGianXuatHien);
            // ranDomQV = UnityEngine.Random.Range(0, taoQuaiVat.Length);
            // ranDomViTri = UnityEngine.Random.Range(0, 2);
            // hienQV = Instantiate(taoQuaiVat[ranDomQV]);
            hienQV = Instantiate(taoQuaiVat[0]);
            hienQV.transform.position = vtXuatHien1.position;
            if (hienQV == taoQuaiVat[0])
            {
                hienQV.transform.localScale = new Vector3(1f, 1f, 1f);
            }
            if (taoQuaiVat.Length > 1)
            {
                if (i == soLanXuatHien - 1)
                {
                    hienQV = Instantiate(taoQuaiVat[1]);
                    hienQV.transform.position = vtXuatHien1.position;
                    hienQV.transform.localScale = new Vector3(2f, 2f, 2f);
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
    }


}
