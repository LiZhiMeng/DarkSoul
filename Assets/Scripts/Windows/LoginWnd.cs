using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginWnd : WindowRoot {

    public InputField usernameIpt;
    public InputField pwdIpt;
    public Button noticeBtn;
    public Button enterBtn;

    public void Init()
    {

        if(PlayerPrefs.GetString("username")!="" && PlayerPrefs.GetString("password") != "")
        {
            this.usernameIpt.text = PlayerPrefs.GetString("username");
            this.pwdIpt.text = PlayerPrefs.GetString("password");
        }
        else
        {
            usernameIpt.text = "";
            pwdIpt.text = "";
        }

    }


    public void ClickEnterBtn()
    {
        AudioSVC.Instance.PlayUIAudio(Constant.AudioLogin);

        if (usernameIpt.text != "" && pwdIpt.text != "")
        {
            PlayerPrefs.SetString("username", usernameIpt.text);
            PlayerPrefs.SetString("password", pwdIpt.text);
            LoginSys.Instance.LoginSuccess();
        }
        else
        {
            GameRoot.AddTips("账号或密码为空");
        }
    }

    public void ClickNoticeBtn()
    {
        GameRoot.AddTips("waitting...");
    }

}
