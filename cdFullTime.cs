using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class cdFullTime : parentcd
{
    float time = -1e6f;
    float cooldown = 0f;
    Action<GameObject> func;
    Action<GameObject> finish;
    GameObject obj;
    public override void init(float cooldown, Action<GameObject> func, Action<GameObject> fin = null, GameObject obj = null)
    {
        time = 0;
        this.cooldown = cooldown;
        func(obj);
        this.func = func;
        this.obj = obj;
        this.finish = fin;
    }


    // Update is called once per frame
    public override void upd(float dt)
    {
        time += dt;
        if (time >= cooldown)
        {
            Debug.Log("Cooldown ended");
            cooldown = 0;
            func(obj);
        }
    }

    public override void stop()
    {
        if(finish != null)finish(obj);
        time = -1e6f;
        Destroy(this);
    }
}
