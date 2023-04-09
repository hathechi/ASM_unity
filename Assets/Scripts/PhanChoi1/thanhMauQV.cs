using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thanhMauQV : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    public Slider sliderHeart;

    //Các biến khi quói vật chết sẽ rơi đồ ra
    public bool drop;
    public GameObject theDrop;


    void Start()
    {
        currentHealth = maxHealth;
        sliderHeart.maxValue = currentHealth;
        sliderHeart.value = currentHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addDamge(float damge)
    {
        currentHealth = currentHealth - damge;
        sliderHeart.value = currentHealth;
        if (currentHealth <= 0)
        {
            if (drop)
            {
                Instantiate(theDrop, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
