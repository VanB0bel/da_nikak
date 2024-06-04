using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject EnemyToSpawn;
    public GameObject player;
    public Vector3 origin = Vector3.zero;
    public float radius = 10f;
    public List<GameObject> enemies = new List<GameObject>();
    public float ttime = 0f;
    public float cooldown = 2f;
    public float spawnrad = 150f;
    public float spawnx;
    public float spawny = 2f;
    public bool running = true;
    public float enemycnt = 0;
  
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
    void Start()
    {
        spawnrad = 169f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (running)
        {
            ttime += Time.deltaTime;
            if (ttime >= cooldown)
            {
                ttime = 0;
                spawnx = UnityEngine.Random.Range(-13f, 13f);
                float znak;
                if (UnityEngine.Random.Range(-1f, 1f) > 0) znak = 1f;
                else znak = -1f;
                spawny = sqrt2(spawnrad - (spawnx * spawnx)) * znak;

                Vector3 randpos = new Vector3(spawnx + player.transform.position.x, spawny + player.transform.position.y, 0);
                var newenemy = Instantiate(EnemyToSpawn, randpos, Quaternion.identity);
                enemies.Add(newenemy);
                newenemy.GetComponent<supershtuka>().initt();
                enemycnt += 1f;
                cooldown -= 0.01f;
                if (cooldown < 1f) cooldown = 1f;
            }
        }
    }
}
