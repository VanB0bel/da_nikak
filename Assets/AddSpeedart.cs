using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;

public class AddSpeedart : MonoBehaviour
{
    List<string> split(string s)
    {
        List<string> res = new List<string>();
        string ss = "";
        for(int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
            {
                ss += s[i];
            }
            else
            {
                res.Add(ss);
                ss = "";
            }
        }
        if (ss != "") res.Add(ss);
        return res;
    }

    public void lvlincrease()
    {
        
        string path = "Assets/playerdata.txt";
        string[] a = File.ReadAllLines(path);
        List<List<string>> b = new List<List<string>>();
        for(int i = 0; i < a.Length; i++)
        {
            b.Add(split(a[i]));
        }
        int x = Convert.ToInt32(b[1][1]);
        x++;
        b[1][1] = x.ToString();
        string s = "";
        for(int i = 0; i < b.Count; i++)
        {
            for(int j = 0; j < b[i].Count; j++)
            {
                s += b[i][j] + " ";
            }
            s += "\n";
        }
        File.WriteAllText(path, s);
    }

}
