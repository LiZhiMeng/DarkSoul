using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSVC : MonoBehaviour {

    public AudioSource BGAudio;
    public AudioSource UIAudio;
    public static AudioSVC Instance =  null;

    public void Init()
    {
        Instance = this;
    }

    public void PlayBGAudio(string name,bool isLoop)
    {
        AudioClip audioClip = ResSVC.Instance.LoadAudio("ResAudio/"+name, isLoop);
        if( audioClip != null && BGAudio.clip != audioClip)
        {
            BGAudio.clip = audioClip;
            BGAudio.loop = isLoop;
            BGAudio.Play();
        }
    }

    public void PlayUIAudio(string name,bool isCache = false)
    {
        AudioClip audioClip =  ResSVC.Instance.LoadAudio("ResAudio/"+name, isCache);
        if(audioClip!=null && UIAudio != null)
        {
            UIAudio.clip = audioClip;
            UIAudio.loop = false;
            UIAudio.Play();
        }
    }
}
