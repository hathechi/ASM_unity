using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;

public class playFab_controller : MonoBehaviour
{
    public InputField txtEmail_login;
    public InputField txtPass_login;
    public InputField txtUserName_regis;
    public InputField txtEmail_regis;
    public InputField txtPass_regis;
    public Text errorText;

    //Open Pannel Register
    public GameObject pannelRegister;

    public void Register()
    {
        var req = new RegisterPlayFabUserRequest
        {
            Username = txtUserName_regis.text,
            Email = txtEmail_regis.text,
            Password = txtPass_regis.text,
            DisplayName = txtUserName_regis.text,
            RequireBothUsernameAndEmail = false,
        };
        //gọi api lên thực hiện
        PlayFabClientAPI.RegisterPlayFabUser(req, onSuccess, onError);
        void onSuccess(RegisterPlayFabUserResult result)
        {
            errorText.text = "Register Success";
            Debug.Log("Register Success " + result.ToString());

        };
        void onError(PlayFabError err)
        {
            errorText.text = err.ToString();
            Debug.Log(err.ToString());
        };
    }

    public void Login()
    {

        var req = new LoginWithPlayFabRequest
        {
            Username = txtEmail_login.text,
            Password = txtPass_login.text
        };

        //goi api thuc hien chuc nang dang nhap
        PlayFabClientAPI.LoginWithPlayFab(req, onLoginSuccess, onErrorLogin);
        void onLoginSuccess(LoginResult result)
        {

            diemDungChung.namePlayerStatic = txtEmail_login.text;
            Debug.Log("Login Success");
            Debug.Log(" diemDungChung.namePlayerStatic: " + diemDungChung.namePlayerStatic);
            //Lưu Điểm 
            Sendleaderboard(0);

            //Chuyển Màn
            SceneManager.LoadScene("Menu");


        }
        void onErrorLogin(PlayFabError error)
        {
            errorText.text = error.ToString();
            Debug.Log(error.ToString());
        }
    }

    public void openPannelRegis()
    {
        pannelRegister.SetActive(true);
    }
    public void closePannelRegis()
    {
        pannelRegister.SetActive(false);
    }

    // ----------------------Thêm Data vào Table------------------
    public GameObject rowPrefab;// dòng chứa thông tin 
    public Transform rowParent;

    public void Sendleaderboard(int score)
    {
        var req = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate> { new StatisticUpdate()
                {
                StatisticName="BangDiem",
                Value=score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(req, OnLeaderboardupdate, OnError);
    }
    void OnLeaderboardupdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("PUT DIEM Success");
    }
    public void getLeaderBoardAround()
    {

        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "BangDiem",
            MaxResultsCount = 5
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, onLeaderboardAroundGet, OnError);

    }
    public void onLeaderboardAroundGet(GetLeaderboardAroundPlayerResult result)
    {

        foreach (Transform item in rowParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            // if (item.DisplayName == diemDungChung.namePlayerStatic)
            // {
            //     diemDungChung.diem = item.StatValue;
            //     Debug.Log("Diem tu DB " + diemDungChung.diem.ToString());
            // }
            GameObject newGo = Instantiate(rowPrefab, rowParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            if (item.DisplayName != null)
            {
                texts[1].text = item.DisplayName;
            }
            texts[2].text = item.StatValue.ToString();
            Debug.Log(item.Position + " " + item.PlayFabId + item.StatValue);


        }

    }
    //
    public void getLeaderBoard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "BangDiem",
            StartPosition = 0,
            MaxResultsCount = 20
        };
        PlayFabClientAPI.GetLeaderboard(request, onLeaderboardGet, OnError);
    }
    public void onLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in rowParent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowParent);
            Text[] texts = newGo.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName.ToString();
            texts[2].text = item.StatValue.ToString();
            Debug.Log(item.Position + " " + item.PlayFabId + item.StatValue);
        }
    }
    void OnError(PlayFabError error)
    {
        errorText.text = error.ToString();
        Debug.Log(error.ToString());
    }


    // ----------------------Show Pannel-------------------------
    public GameObject pannelDiem;

    public void openPannelRank()
    {
        pannelDiem.SetActive(true);
    }
    public void closePanneRank()
    {
        pannelDiem.SetActive(false);
    }

}
