using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class diChuyenNV : MonoBehaviour
{

    //Thuộc tính đầu vào của người chơi
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private string NhanVat_DiChuyen = "NVRun";
    private string NhanVat_Nhay = "NVJump";
    [SerializeField]
    private float vatToc = 5f;
    [SerializeField]
    private float lucNhay = 7f;
    private float diChuyenX;
    private float nhanVatNhay;
    private bool trenMatDat = true; //kiem tra xem nhan vat co o tren mat dat hay k ?
    private string tag_MatDat = "MATDAT";
    // private string tag_QuaiVat = "QUAIVAT";
    //Biến kiểm tra hướng của nhân vật
    private bool isFace;

    //Khai báo các biến để phi kiếm 
    public Transform viTriBan;
    public GameObject kiem;
    public float fireRate = 0.5f;
    public float nextFire = 0;

    bool getKey = false;  //Nhặt chìa khóa cuối cùng để qua được màn chơi;

    //Âm thanh 
    public AudioSource sound_vatPham;
    public AudioSource sound_phiKiem;
    public AudioSource sound_damage;
    //Tên màn chơi 
    string nameScenes;

    //Khi nhặt được key sẽ hiện lên màn hình canvas
    public GameObject visible_Key;

    //Hien thi ten dang nhap
    public Text userName;

    //Diem
    int diemBanDau = 0;
    public Text diamon;



    void Start()
    {


        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        nameScenes = SceneManager.GetActiveScene().name;
        diemDungChung.nameScenesStatic = nameScenes;

        if (diemDungChung.namePlayerStatic != null)
        {
            userName.text = diemDungChung.namePlayerStatic;
        }
        if (diemDungChung.diem != 0)
        {
            diamon.text = diemDungChung.diem.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        NhanVatDiChuyen();
        AnimationDiChuyen();
        AnimationNhay();
        phiKiem();
    }

    private void phiKiem()
    {

        if (Input.GetAxisRaw("Jump") > 0)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                sound_phiKiem.Play(0);
                //dichuyenX<0 có nghĩa là nhân vật quay mặt sang trái
                if (isFace)
                {
                    Instantiate(kiem, viTriBan.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                    // nextFire = 0;
                }
                else if (isFace == false)
                {
                    Instantiate(kiem, viTriBan.position, Quaternion.Euler(new Vector3(-0, 0, 180)));
                    // nextFire = 0;


                }
            }
        }
    }

    private void AnimationNhay()
    {
        if (nhanVatNhay > 0)
        {
            anim.SetBool(NhanVat_Nhay, true);
        }
    }

    private void AnimationDiChuyen()
    {
        if (diChuyenX < 0)
        {
            anim.SetBool(NhanVat_DiChuyen, true);
            sprite.flipX = true;
            isFace = false;
        }
        else if (diChuyenX > 0)
        {
            anim.SetBool(NhanVat_DiChuyen, true);
            sprite.flipX = false;
            isFace = true;
        }
        else
        {
            anim.SetBool(NhanVat_DiChuyen, false);

        }
    }

    private void NhanVatDiChuyen()
    {

        diChuyenX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(diChuyenX, 0, 0) * vatToc * Time.deltaTime;
        nhanVatNhay = Input.GetAxisRaw("Vertical");
        if (nhanVatNhay > 0 && trenMatDat)
        {
            rb.AddForce(new Vector2(rb.velocity.x, lucNhay), ForceMode2D.Impulse);
            trenMatDat = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(tag_MatDat))
        {
            trenMatDat = true;
            anim.SetBool(NhanVat_Nhay, false);
        }
        //roi xuong vuc chet
        if (other.gameObject.CompareTag("GIOIHANROI"))
        {
            diemDungChung.nameScenesStatic = nameScenes;
            Destroy(gameObject);
            SceneManager.LoadScene("Replay");
        }
    }
    //them diem khi nhat diamon
    public void addDiamon(int diem)
    {
        sound_vatPham.Play(0);
        diemBanDau += diem;
        diamon.text = diemBanDau.ToString();
        diemDungChung.diem = diemBanDau;
        //Lưu điểm lên PlayFab
        diemDungChung.playFab.Sendleaderboard(diemDungChung.diem);

    }
    //Người chơi nhặt được chìa khóa
    private void OnTriggerEnter2D(Collider2D other)

    {


        if (other.gameObject.CompareTag("KEY"))
        {
            sound_vatPham.Play(0);
            getKey = true;
            if (getKey)
            {
                visible_Key.SetActive(true);
            }

        }
        if (other.gameObject.CompareTag("CUAQUAMAN"))
        {

            //Lấy tên Scenes hiện tại
            nameScenes = SceneManager.GetActiveScene().name;
            if (nameScenes == "Map1")
            {
                nameScenes = "Map2";
            }
            else if (nameScenes == "Map2")
            {
                nameScenes = "Map3";
            }
            else if (nameScenes == "Map3")
            {
                nameScenes = "Map4";
            }
            else if (nameScenes == "Map4")
            {
                nameScenes = "Map5";
            }
            else if (nameScenes == "Map5")
            {
                nameScenes = "Finish";
            }
            Debug.Log("Màn 1 " + getKey);
            if (getKey)
            {
                SceneManager.LoadScene(nameScenes);
                // getKey = false;
            }
        }

        if (other.gameObject.CompareTag("QUAIVAT"))
        {
            sound_damage.Play(0);
        }
        if (other.gameObject.CompareTag("TIM"))
        {
            sound_vatPham.Play(0);
        }
    }
}
