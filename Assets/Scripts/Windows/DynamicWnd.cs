using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot
{

    public Animation tipsAnimation;
    public Text tipsText;

    protected override void InitWindowRoot()
    {
        base.InitWindowRoot();
        Debug.Log("弹出提示");
        tipsText.gameObject.SetActive(false);
    }

    private Queue<string> Qstring = new Queue<string>();

    //使用队列显示 提示文字
    public void AddTips(string tipsString)
    {
        Qstring.Enqueue(tipsString);
    }

    public void SetTips()
    {
        string tipsString = Qstring.Dequeue();
        tipsText.text = tipsString;
        tipsText.gameObject.SetActive(true);
        AnimationClip animClip = tipsAnimation.GetClip("TipsAnimation");
        tipsAnimation.Play();
        StartCoroutine(PlayTipsAnim(animClip.length, () =>
        {
            tipsText.gameObject.SetActive(false);
            isTipsShowing = false;
        }));
    }

    private IEnumerator PlayTipsAnim(float delayTime, Action callBack)
    {
        yield return new WaitForSeconds(delayTime);
        callBack();
    }

    bool isTipsShowing = false;
    private void Update()
    {

        if (Qstring.Count > 0)
        {
            if (!isTipsShowing)
            {
                isTipsShowing = true;
                SetTips();
            }
        }
    }
}
