using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 资源服务
/// </summary>
public class ResSVC : MonoBehaviour {

    /// <summary>
    /// 服务模块初始化
    /// </summary>
    public void Init()
    {
        Instance = this;
        Debug.Log("服务模块初始化");
    }

    private Action pgAction = null;
    public void LoadScene(string sceneName,Action loadWnd)
    {
        GameRoot.Instance.loadingWnd.SetStateEnter(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        pgAction = () =>
        {
            GameRoot.Instance.loadingWnd.SetProgress(operation.progress);
            if (operation.progress == 1)
            {
                GameRoot.Instance.loadingWnd.SetStateEnter(false);
                operation = null;
                pgAction = null;
                if (loadWnd != null)
                {
                    loadWnd();
                }
            }
        };

    }

    public static ResSVC Instance = null;

    private void Update()
    {
        if (pgAction != null)
        {
            pgAction();
        }
    }

    Dictionary<string, AudioClip> audioDic = new Dictionary<string, AudioClip>();
    public AudioClip LoadAudio(string name,bool isCache)
    {
        if (isCache)
        {
            if (audioDic.ContainsKey(name))
            {
                return audioDic[name];
            }
            else
            {
                AudioClip audioClip = Resources.Load<AudioClip>(name);
                audioDic.Add(name, audioClip);
                return audioClip;
            }
        }
        else
        {
            AudioClip audioClip = Resources.Load<AudioClip>(name);
            return audioClip;
        }
    }

    List<string> surNameList = new List<string>();
    List<string> manList = new List<string>();
    List<string> womanList = new List<string>();
    public void InitRDNameCfg()
    {
        TextAsset xml = Resources.Load<TextAsset>(PathDefine.RDNameConfig);
        if (xml==null)
        {
            Debug.LogError(PathDefine.RDNameConfig + " xml is null");
        }
        else
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml.text);
            XmlNodeList nodeList = xmlDocument.SelectSingleNode("root").ChildNodes;
            for(int i = 0; i < nodeList.Count; i++)
            {
                XmlElement element = nodeList[i] as XmlElement;

                if (element.GetAttributeNode("ID") == null)
                {
                    continue;
                }
                //int ID = Convert.ToInt32( element.GetAttributeNode("ID").InnerText);
                foreach (XmlElement e  in element.ChildNodes)
                {
                    switch (e.Name)
                    {
                        case "surname": surNameList.Add(e.InnerText);break;
                        case "man": manList.Add(e.InnerText); break;
                        case "woman": womanList.Add(e.InnerText); break;
                    }
                }
            }
        }
    }

}
