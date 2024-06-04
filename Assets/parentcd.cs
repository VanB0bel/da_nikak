using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class parentcd : MonoBehaviour
{
    // Start is called before the first frame update
    abstract public void upd(float dt);
    virtual public void stop() 
    {
        Debug.Log("Parentcd stop");
    }
    virtual public void init(float secs, float cd, Action<GameObject> fun, GameObject obj = null)
    {
        Debug.Log("Parentcd init");
    }
    virtual public void init(float cooldown, Action<GameObject> func, Action<GameObject> fin = null, GameObject obj = null)
    {
        Debug.Log("Parentcd init");
    }
    virtual public void init(float cooldown, Action funcStart, Action funcEnd)
    {
        Debug.Log("Parentcd init");
    }



}
