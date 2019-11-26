using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 登录系统
/// </summary>
public class LoginSys : SysRoot {


    public LoginWnd loginWnd;
    public CreateWnd createWnd;
    public static LoginSys Instance;
    /// <summary>
    /// 业务模块初始化
    /// </summary>
    public override void InitSVC()
    {
        base.InitSVC();
        Instance = this;
        Debug.Log("业务模块初始化");
    }


    /// <summary>
    /// 进入 登录场景
    /// </summary>
    public void EnterLogin()
    {
        Debug.Log("进入 登录场景");
        //异步加载登录场景； 同时 更新进度条 ； 完成后进入注册界面；
        resSVC.LoadScene(Constant.SCENELOGIN, ()=>
        {
            loginWnd.gameObject.SetActive(true);
            loginWnd.Init();
        });
    }

    public void LoginSuccess()
    {
        loginWnd.SetStateEnter(false);
        createWnd.SetStateEnter();
    }






}
