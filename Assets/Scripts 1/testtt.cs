using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testtt : MonoBehaviour
{

    public Text supertext;
    public int cntt;
    public int sss;

    void Start()
    {
        cntt = 0;
        sss = 1;
    }

    public void clickkk()
    {
        cntt += sss;
        supertext.text = cntt.ToString();
    }
}
