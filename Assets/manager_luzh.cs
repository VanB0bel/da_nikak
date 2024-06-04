using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager_luzh : MonoBehaviour
{
    public GameObject luzhik;
    public GameObject player;
    public List<float> cooldown;
    public List<GameObject> luzhiks;
    public float ttime = 0f;
    public float cddva = 2.5f;
    float x, y, r;
    public List<float> times;
    Vector3 pos;
    bool active = false;

    private void Start()
    {
        times.Add(0.0f);
        cooldown.Add(2.5f);
        luzhiks.Add(luzhik);
    }


    void init()
    {
        x = player.transform.position.x;
        y = player.transform.position.y;
        r = 2;
        pos = new Vector3(x, y, 0);
        Instantiate(luzhik, pos, Quaternion.identity);
        luzhik.transform.localScale = new Vector3(r, r, 1);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < times.Count; i++)
        {
            ttime = times[i];
            ttime += Time.fixedDeltaTime;
            if (ttime >= cooldown[i]) // dopilit proverku poluchili li mi spell
            {
                if (FindObjectOfType<NewManager>().enemies.Count == 0)
                {
                    continue;
                }
                else
                {
                    init();
                    ttime = 0;

                }
            }
            times[i] = ttime;
        }
    }
}
