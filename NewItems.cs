using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewItems : MonoBehaviour
{
    public float cooldown;
    public float dtime;
    public float spawnx;
    public float spawny;
    public float spawnrad;
    public List<GameObject> items_ = new List<GameObject>();
    public GameObject ItemToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = UnityEngine.Random.Range(10, 20);
        dtime = 0;
        spawnrad = 64;
    }

    float sqrt2(float x)
    {
        float l = 0.0f;
        float r = Math.Abs(x) + 1f;
        while (r - l > 1e-5)
        {
            float m = (r + l) / 2f;
            if (m * m < x) l = m;
            else r = m;
        }
        return l;
    }

    // Update is called once per frame
    void Update()
    {
        dtime += Time.deltaTime;
        if (dtime > cooldown)
        {
            dtime = 0;
            cooldown = UnityEngine.Random.Range(10, 20);
            spawnx = UnityEngine.Random.Range(-8f, 8f);
            float znak;
            if (UnityEngine.Random.Range(-1f, 1f) > 0) znak = 1f;
            else znak = -1f;
            spawny = sqrt2(spawnrad - (spawnx * spawnx)) * znak;

            Vector3 randpos = new Vector3(spawnx + GameObject.Find("Square").transform.position.x, spawny + GameObject.Find("Square").transform.position.y, 0);
            var newitem = Instantiate(ItemToSpawn, randpos, Quaternion.identity);
            items_.Add(newitem);
            newitem.GetComponent<NewItemOdin>().initt();
        }
    }
}
