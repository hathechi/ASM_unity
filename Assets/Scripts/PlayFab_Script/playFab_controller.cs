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

}
