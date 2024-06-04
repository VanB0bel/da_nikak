using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewManager : MonoBehaviour
{
    public GameObject EnemyToSpawn;
    public GameObject EnemyToSpawnDva;
    public GameObject player;
    public Vector3 origin = Vector3.zero;
    public float radius = 10f;
    public List<GameObject> enemies = new List<GameObject>();
    
    public float spawnrad = 150f;
    public float spawnx;
    public float spawny = 2f;
    public bool running = true;
    public float enemycnt = 0;
    public List<GameObject> available_enemies;

    public List<float> times;
    public List<float> cooldown;

    bool dvaready = false;


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
        available_enemies.Add(EnemyToSpawn);
        available_enemies.Add(EnemyToSpawnDva);

        times.Add(0.0f);
        times.Add(0.0f);

        cooldown.Add(2.0f);
        cooldown.Add(10.0f);
    }
    // Update is called once per frame

    void spawnenemy(int type)
    {
        spawnx = UnityEngine.Random.Range(-13f, 13f);
        float znak;
        if (UnityEngine.Random.Range(-1f, 1f) > 0) znak = 1f;
        else znak = -1f;
        spawny = sqrt2(spawnrad - (spawnx * spawnx)) * znak;
        
        Vector3 randpos = new Vector3(spawnx + player.transform.position.x, spawny + player.transform.position.y, 0);
        var newenemy = Instantiate(available_enemies[type], randpos, Quaternion.identity);
        enemies.Add(newenemy);
        newenemy.GetComponent<NewEnemy>().initt(type);
        enemycnt += 1f;
        cooldown[type] -= 0.01f;
        if (cooldown[type] < 1f) cooldown[type] = 1f;
    }

    void FixedUpdate()
    {
        if (running)
        {
            for (int i = 0; i < times.Count; i++)
            {
                if (i == 1)
                {
                    if (!dvaready)
                    {
                        times[i] += Time.fixedDeltaTime;
                        if (times[i] > 40f) dvaready = true;
                        else continue;
                    } 
                    
                }
                times[i] += Time.fixedDeltaTime;
                if (times[i] >= cooldown[i])
                {
                    times[i] = 0;
                    spawnenemy(i);
                }
            }
        }
    }
}
