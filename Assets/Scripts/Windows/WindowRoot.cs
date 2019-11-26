using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// UI窗口基类
/// </summary>
public class WindowRoot : MonoBehaviour {


    ResSVC resSvc;
    public void SetStateEnter(bool isActive = true)
    {
        if (gameObject.activeSelf != isActive)
        {
            gameObject.SetActive(isActive);
        }

        if (isActive)
        {
            InitWindowRoot();
        }
        else
        {
            CloseWindowRoot();
        }
    }

    protected virtual void InitWindowRoot()
    {
        resSvc = ResSVC.Instance;
    }

    protected virtual void CloseWindowRoot()
    {
        resSvc = null;

    }

    #region otherTools
    public void SetActive(GameObject go,bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    #endregion


}
