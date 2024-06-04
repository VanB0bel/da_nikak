using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chances : MonoBehaviour
{
    int chance_pos = 0, chance_all = 0;
    Action<GameObject> func = null;
    public void init(int pos, int all, Action<GameObject> fun)
    {
        this.func = fun;
        this.chance_pos = pos;
        this.chance_all = all;
    }


    public void imcast(int pos, int all, Action<GameObject> fun, GameObject obj)
    {
        int val = UnityEngine.Random.Range(0, all);
        if (val <= pos)
        {
            fun(obj);
        }
    }

    void cast(GameObject obj)
    {
        int val = UnityEngine.Random.Range(0, chance_all);
        if (val <= chance_pos)
        {
            func(obj);
        }

    }
}
