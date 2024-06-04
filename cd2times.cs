using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cd2times : parentcd
{
    float time = -1e6f;
    float cooldown = 0f;
    Action funcEnd;
    public override void init(float cooldown, Action funcStart, Action funcEnd)
    {
        time = 0;
        this.cooldown = cooldown;
        funcStart();
        this.funcEnd = funcEnd;
    }

    
    // Update is called once per frame
    public override void upd(float dt)
    {
        time += dt;
        if (time >= cooldown)
        {
            Debug.Log("Cooldown ended");
            cooldown = 0;
            funcEnd();
            time = -1e6f;

        }
    }
}
