using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour {

    public LoadingWnd loadingWnd;
    public static GameRoot Instance = null;
    private void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        Init();
    }

    public void Init()
    {

        //服务模块初始化
        ResSVC resSVC = this.GetComponent<ResSVC>();
        resSVC.Init();

        //业务系统初始化
        LoginSys loginSys = this.GetComponent<LoginSys>();
        loginSys.Init();

        //进行登录场景
        loginSys.EnterLogin();



    }
}
