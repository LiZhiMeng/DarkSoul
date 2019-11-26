using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 加载进度条界面
/// </summary>
public class LoadingWnd : WindowRoot
{

    public Image RoleBallImg;
    public Image loadingFg;
    public Text ProgressTip;
    public Text SkillTips;
    private float loadingFgWidth;

    protected override void InitWindowRoot()
    {
        base.InitWindowRoot();
        SkillTips.text = "Tips:带有霸体状态的技能在施放时可以规避控制";
        loadingFgWidth = loadingFg.GetComponent<RectTransform>().sizeDelta.x; //得到进度条的宽度
        ProgressTip.text = "0%"; //百分比
        ProgressTip.GetComponent<RectTransform>().localPosition = new Vector2(-500 / 2, ProgressTip.GetComponent<RectTransform>().localPosition.y);
        RoleBallImg.GetComponent<RectTransform>().localPosition = new Vector2(-500 / 2, RoleBallImg.GetComponent<RectTransform>().localPosition.y); ;//进度条上的圆球图
        loadingFg.fillAmount = 0;//进度条百分比
    }

    /// <summary>
    /// 刷新进度
    /// </summary>
    /// <param name="progress"></param>
    public void SetProgress(float progress)
    {
        float cur_flag = progress >= 0.5f ? 1 : -1;
        float cur_Posx = cur_flag * progress * loadingFgWidth / 2;
        ProgressTip.GetComponent<RectTransform>().localPosition = new Vector2(cur_Posx, ProgressTip.GetComponent<RectTransform>().localPosition.y);
        Debug.Log("cur_Posx:" +cur_Posx);
        RoleBallImg.GetComponent<RectTransform>().localPosition = new Vector2(cur_Posx, RoleBallImg.GetComponent<RectTransform>().localPosition.y);
        loadingFg.fillAmount = progress;
        ProgressTip.text = progress * 100 + "%";  
    }


}
