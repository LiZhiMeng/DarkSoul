using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopDragonAnim : MonoBehaviour {

    private Animation animation;

    private void Awake()
    {
        animation = GetComponent<Animation>();
    }

    void Start () {
        if (animation != null)
        {
            InvokeRepeating("PlayAnim", 0, 20);
        }
    }

    void PlayAnim()
    {
        animation.Play();
    }
	

}
