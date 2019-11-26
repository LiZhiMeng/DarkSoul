using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 游戏全局控制器
/// </summary>
public class GameRoot : MonoBehaviour {

    public LoadingWnd loadingWnd;
    public DynamicWnd dynamicWnd;
    public static GameRoot Instance = null;
    private void Start()
    {
        DontDestroyOnLoad(this);
        
        Instance = this;
        HideGameRoot();
        Init();
    }

    public void HideGameRoot()
    {
        GameObject canvasGo = transform.Find("Canvas").gameObject;
        for(int i = 0; i < canvasGo.transform.childCount; i++)
        {
            canvasGo.transform.GetChild(i).gameObject.SetActive(false);
        }
        Instance.dynamicWnd.gameObject.SetActive(true);
    }

    public void Init()
    {

        //服务模块初始化
        ResSVC resSVC = this.GetComponent<ResSVC>();
        resSVC.Init();

        //音乐管理器
        AudioSVC audioSVC = this.GetComponent<AudioSVC>();
        audioSVC.Init();

        //业务系统初始化
        LoginSys loginSys = this.GetComponent<LoginSys>();
        loginSys.InitSVC();

        //进行登录场景
        loginSys.EnterLogin();

        AudioSVC.Instance.PlayBGAudio(Constant.BGMAINCITY,true);

        AddTips("aaaaa");
        AddTips("aaaaabbb");
        AddTips("aaaaccccca");

    }

    public static void AddTips(string tipsString)
    {
        Instance.dynamicWnd.AddTips( tipsString);
    }
}
