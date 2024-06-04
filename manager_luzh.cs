using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager_luzh : MonoBehaviour
{
    public GameObject luzhik;
    float x, y, r;
    public float cooldown;
    Vector3 pos;
    bool active = false;

    void init()
    {
        x = 0;
        y = 0;
        r = 2;
        pos = new Vector3(x, y, 0);
        Instantiate(luzhik, pos, Quaternion.identity);
        luzhik.transform.localScale = new Vector3(r, r, 1);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!active) init();
        active = true;
    }
}
