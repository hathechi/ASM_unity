using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panel;
    List<string> listMaps = new List<string> { "Map1", "Map2", "Map3", "Map4", "Map5" };

    public Text userName;
    private void Start()
    {
        if (diemDungChung.namePlayerStatic != null)
        {
            userName.text = "Hi: " + diemDungChung.namePlayerStatic.ToString();
        }
        else
        {
            return;
        }
    }

    public void Play()
    {
        panel.SetActive(true);
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
        SceneManager.LoadScene(listMaps[0]);
    }
    public void Level2()
    {
        SceneManager.LoadScene(listMaps[1]);
    }
    public void Level3()
    {
        SceneManager.LoadScene(listMaps[2]);
    }
    public void Level4()
    {
        SceneManager.LoadScene(listMaps[3]);
    }
    public void Level5()
    {
        SceneManager.LoadScene(listMaps[4]);
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
