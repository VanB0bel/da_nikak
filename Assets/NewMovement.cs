using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Text;
using System.IO;

public class NewMovement : MonoBehaviour
{

    public float exp = 0f;
    public float level = 1f;
    public float exp_to_up = 15f;
    public float max_hp = 120f;
    public float hp = 100f;
    public float movementspeed = 6f;
    public float dmgup = 1f;
    public float critch = 10f; // ne ispolzuetsya
    public float critdmg = 150f; // tozhe
    public float cdreduce = 1f; // tozhe
    public float sprad = 1f; //
    public float dura = 1f;//
    public GameObject buttonodin;
    public GameObject buttondva;
    public GameObject buttontri;
    public GameObject endbutton_;
    public List<int> avspl;
    public List<int> num_spells;
    public List<int> arts;
    public float curmoney = 0;


    Vector2 moveup = Vector2.up;
    Vector2 movedown = Vector2.down;
    Vector2 moveleft = Vector2.left;
    Vector2 moveright = Vector2.right;

    List<string> split(string s)
    {
        List<string> res = new List<string>();
        string ss = "";
        for (int i = 0; i < s.Length; i++)
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

    void Start()
    {
        exp_to_up = 15;
        avspl = FindObjectOfType<NewGun>().available_spells; // 
        movementspeed = 6f;
        for (int i = 0; i < 4; i++)
        {
            num_spells.Add(i);
        }

        string path = "Assets/playerdata.txt";
        string[] a = File.ReadAllLines(path);
        List<List<string>> b = new List<List<string>>();
        for (int i = 0; i < a.Length; i++)
        {
            b.Add(split(a[i]));
        }
        for (int i = 0; i < a.Length; i++)
        {
            arts.Add(Convert.ToInt32(b[i][b[i].Count - 1]));
        }

    }

    void FixedUpdate()
    {
        curmoney += Time.fixedDeltaTime;
        movementspeed = 6f + 1.5f * avspl[avspl.Count - 1] + 10 * arts[1]; // zachem eto tut?
        if (FindObjectOfType<NewManager>().running)
        {
            if (Input.GetKey("w"))
            {
                transform.Translate(moveup * movementspeed * Time.fixedDeltaTime);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(movedown * movementspeed * Time.fixedDeltaTime);
            }
            if (Input.GetKey("d"))
            {
                transform.Translate(moveright * movementspeed * Time.fixedDeltaTime);
            }
            if (Input.GetKey("a"))
            {
                transform.Translate(moveleft * movementspeed * Time.fixedDeltaTime);
            }
            if (exp >= exp_to_up)
            {
                exp -= exp_to_up;
                exp_to_up *= 1.5f;
                level++;
                dmgup += 0.1f;
                max_hp += 15f;
                hp *= 1.2f;
                if (hp > max_hp) hp = max_hp;
                buttonodin.SetActive(true);
                buttondva.SetActive(true);
                buttontri.SetActive(true);
                for (int i = 0; i < num_spells.Count; i++)
                {
                    int b = UnityEngine.Random.Range(i, num_spells.Count);
                    int c = num_spells[b];
                    num_spells[b] = num_spells[i];
                    num_spells[i] = c;
                }
                buttonodin.GetComponent<NewButtonUp>().initt(num_spells[0]);
                buttondva.GetComponent<NewButtonUp>().initt(num_spells[1]);
                buttontri.GetComponent<NewButtonUp>().initt(num_spells[2]);
                FindObjectOfType<NewManager>().running = false;
            }
            else if (hp <= 0f)
            {
                string path = "Assets/playerdata.txt";
                string[] a = File.ReadAllLines(path);
                List<List<string>> b = new List<List<string>>();
                for (int i = 0; i < a.Length; i++)
                {
                    b.Add(split(a[i]));
                }

                b[0][0] = (Convert.ToInt32(b[0][0]) + ((int)curmoney / 10)).ToString();
                string s = "";
                for (int i = 0; i < b.Count; i++)
                {
                    for (int j = 0; j < b[i].Count; j++)
                    {
                        s += b[i][j] + " ";
                    }
                    s += "\n";
                }
                File.WriteAllText(path, s);

                endbutton_.SetActive(true);
                FindObjectOfType<NewManager>().running = false;

            }
        }
    }
}
