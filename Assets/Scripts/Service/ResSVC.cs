using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSVC : MonoBehaviour {

    /// <summary>
    /// 服务模块初始化
    /// </summary>
    public void Init()
    {
        Instance = this;
        Debug.Log("服务模块初始化");
    }

    public void LoadScene(string sceneName)
    {
        GameRoot.Instance.loadingWnd.gameObject.SetActive(true);
        SceneManager.LoadSceneAsync(sceneName);
    }

    public static ResSVC Instance = null;

    
}
