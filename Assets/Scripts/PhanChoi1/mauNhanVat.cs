using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mauNhanVat : MonoBehaviour
{
    public float maxHealth;
    public static float currentHealth;
    public Image hieuUngMatMau;
    //Tạo biến kiểm tra xem nhân vật có chạm vào Qv hay không
    bool isDamge;

    // biến hiệu ứng màu 
    Color damagedColour = new Color(5f, 5f, 0f, 0.5f);
    float smoothColour = 5f;

    public Slider sliderHeart;

    // public AudioClip sound_damage;
    // AudioSource audioSource;


    void Start()
    {
        Debug.Log("Start DIem " + (diemDungChung.currentHealthStatic).ToString());

        if (diemDungChung.currentHealthStatic != 0)
        {
            sliderHeart.maxValue = maxHealth;
            sliderHeart.value = diemDungChung.currentHealthStatic;
        }
        else
        {
            currentHealth = maxHealth;
            isDamge = false;
            sliderHeart.maxValue = maxHealth;
            sliderHeart.value = maxHealth;
        }


        // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDamge)
        {
            hieuUngMatMau.color = damagedColour;
        }
        else
        {
            hieuUngMatMau.color = Color.Lerp(hieuUngMatMau.color, Color.clear, smoothColour * Time.deltaTime);
        }
        isDamge = false;
    }
    public void addDamge(float damge)
    {
        if (damge < 1)
        {
            return;
        }
        currentHealth = currentHealth - damge;

        // audioSource.PlayOneShot(sound_damage, 0.7f);

        //Thanh máu nhân vật
        sliderHeart.value = currentHealth;
        isDamge = true;

        diemDungChung.currentHealthStatic = currentHealth;
        Debug.Log("Mau static " + (diemDungChung.currentHealthStatic).ToString());


        if (currentHealth < 1)
        {


            Destroy(gameObject);
            SceneManager.LoadScene("Replay");
        }
    }
    public void addHeart(float heart)
    {
        currentHealth += heart;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        sliderHeart.value = currentHealth;
    }
}
