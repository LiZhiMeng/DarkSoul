using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWnd : WindowRoot {

    protected override void InitWindowRoot()
    {
        base.InitWindowRoot();
        GameRoot.AddTips("登录成功");
    }


}
