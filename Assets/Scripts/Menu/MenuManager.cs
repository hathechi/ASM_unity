using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    string nameScenes;
    public GameObject panel;

    void Start()
    {
        nameScenes = SceneManager.GetActiveScene().name;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play()
    {
        SceneManager.LoadScene("ManChoi1");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ExitGameGuide()
    {
        SceneManager.LoadScene(diemDungChung.nameScenesStatic);
    }
    public void Level()
    {
        panel.SetActive(true);
    }
    public void Level1()
    {
        SceneManager.LoadScene("ManChoi1");

    }
    public void Level2()
    {
        SceneManager.LoadScene("Man2");

    }
    // lấy scene hiện tại
    public void Replay()
    {
        SceneManager.LoadScene(diemDungChung.nameScenesStatic);
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ExitPanel()
    {
        panel.SetActive(false);

    }

}
