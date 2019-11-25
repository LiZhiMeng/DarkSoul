using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginSys : MonoBehaviour {

    /// <summary>
    /// 业务模块初始化
    /// </summary>
    public void Init()
    {
        Debug.Log("业务模块初始化");
    }


    /// <summary>
    /// 进入 登录场景
    /// </summary>
    public void EnterLogin()
    {
        Debug.Log("进入 登录场景");

        //异常加载登录场景； 同时 更新进度条 ； 完成后进入注册界面；
        ResSVC.Instance.LoadScene(Constant.SCENELOGIN);

    }



}
