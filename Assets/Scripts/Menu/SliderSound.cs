using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSound : MonoBehaviour
{
    public Slider sliderSound;
    // Start is called before the first frame update
    void Start()
    {
        sliderSound.value = 1;
        AudioListener.volume = diemDungChung.volumeStatic;

    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = sliderSound.value;
        diemDungChung.volumeStatic = sliderSound.value;
    }
}
