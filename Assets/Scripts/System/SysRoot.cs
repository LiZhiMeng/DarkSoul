using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SysRoot : MonoBehaviour {

    protected ResSVC resSVC;
    protected AudioSVC audioSVC;

    public virtual void InitSVC()
    {
        resSVC = ResSVC.Instance;
        audioSVC = AudioSVC.Instance;
    }
}
