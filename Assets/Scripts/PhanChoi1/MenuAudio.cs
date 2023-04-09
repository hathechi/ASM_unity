using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuAudio : MonoBehaviour
{
    public AudioSource audioNen;
    public GameObject pauseScreen;
    public GameObject btnSound;
    public GameObject btnSound1;
    bool isPlay = true;
    string nameScenes;
    private void Awake()
    {
        btnSound.SetActive(true);
        btnSound1.SetActive(false);
        nameScenes = SceneManager.GetActiveScene().name;
    }
    public void AudioPause()
    {
        if (isPlay)
        {
            btnSound.SetActive(false);
            btnSound1.SetActive(true);
            audioNen.Pause();
            isPlay = false;
        }
        else
        {
            btnSound.SetActive(true);
            btnSound1.SetActive(false);
            audioNen.UnPause();
            isPlay = true;

        }
    }
    public void PauseScenes()
    {
        Time.timeScale = 0f;
        btnSound.SetActive(false);
        btnSound1.SetActive(true);
        audioNen.Pause();
        pauseScreen.SetActive(true);
    }
    public void UnPauseScenes()
    {
        Time.timeScale = 1f;
        if (!isPlay)
        {
            btnSound.SetActive(false);
            btnSound1.SetActive(true);
            audioNen.Pause();
        }
        else
        {
            btnSound.SetActive(true);
            btnSound1.SetActive(false);
            audioNen.UnPause();

        }
        pauseScreen.SetActive(false);

    }
    public void GoToHome()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GameGuide()
    {
        diemDungChung.nameScenesStatic = nameScenes;
        SceneManager.LoadScene("HuongDan");
    }
}
