using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cdForTime : parentcd
{
    float sec_need = 0, cooldown = 0;
    Action<GameObject> func;
    float time = 0;
    GameObject obj = null;
    public override void init(float secs, float cd, Action<GameObject> fun, GameObject obj = null)
    {
        this.func = fun;
        this.sec_need = secs;
        this.cooldown = cd;
        this.obj = obj;
    }

    public override void upd(float dt)
    {
        time += dt;
        if(time > sec_need)
        {
            return;
        }
        if(time > cooldown)
        {
            func(obj);
            time -= cooldown;
            sec_need -= cooldown;
        }
    }

}
