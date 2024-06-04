using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewGun : MonoBehaviour
{
    public List<GameObject> bullets = new List<GameObject>(); 
    public GameObject player; 
    public List<float> cooldown;
    public float cddva = 2.5f; 
    public float ttime = 0f; 
    public float ttimedva = 0f; 
    public List<float> speed_bullet; 
    public List<GameObject> missile; 


    public GameObject missiledva;
    public GameObject missiletri;
    public GameObject missilefor;
    //public GameObject missilefive; 

    //public static Vector2 bottomLeft
    //public static Vector2 topRight;
    public List<float> times;
    public List<int> available_spells;
    public List<float> spells_dmg;



    void Start() //
    {
        spells_dmg.Add(10f);
        spells_dmg.Add(3f);
        spells_dmg.Add(5f);
        //spells_dmg.Add(2.5f);

        spells_dmg.Add(0f);
        spells_dmg.Add(0f);
        
        missile.Add(missiledva);
        missile.Add(missiletri);
        missile.Add(missilefor);

        cooldown.Add(2.5f);
        cooldown.Add(1.0f);
        cooldown.Add(1.5f);
        //cooldown.Add(2f);

        times.Add(0.0f);
        times.Add(0.0f);
        times.Add(0.0f);
        //times.Add(0.0f);


        speed_bullet.Add(4f);
        speed_bullet.Add(2f);
        speed_bullet.Add(2f);
        //speed_bullet.Add(4f); 


        available_spells.Add(1);
        for (int i = 1; i < spells_dmg.Count; i++)
        {
            available_spells.Add(0);
        }

        /* 
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        topRight.x *= 1.1f; topRight.y *= 1.1f; // da hz

        Vector3 dv = topRight;
        dv.x *= 0.1f; dv.y *= 0.1f;
        dv.z = 0;
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)) - dv; // */
    }

    void createbullet(GameObject blt, int id)
    {
        Vector3 mindist = player.transform.position - FindObjectOfType<NewManager>().enemies[0].transform.position;
        int ind = 0;
        for (int i = 0; i < FindObjectOfType<NewManager>().enemies.Count; i++) // 
        {
            var enemyy = FindObjectOfType<NewManager>().enemies[i];
            float x = (player.transform.position.x - enemyy.transform.position.x) * (player.transform.position.x - enemyy.transform.position.x);
            float y = (player.transform.position.y - enemyy.transform.position.y) * (player.transform.position.y - enemyy.transform.position.y);
            if ((x + y) < (mindist.y * mindist.y + mindist.x * mindist.x))
            {
                mindist = player.transform.position - enemyy.transform.position;
                ind = i;
            }
        }
        float d = (float)Math.Sqrt(mindist[0] * mindist[0] + mindist.y * mindist.y) / speed_bullet[id];
        float dx = mindist.x / d, dy = mindist.y / d;
        GameObject newbullet = Instantiate(blt, player.transform.position, Quaternion.identity);
        newbullet.GetComponent<NewBullets>().initt(-dx, -dy, id, FindObjectOfType<NewManager>().enemies[ind]);
        bullets.Add(newbullet); // 
        
    }


    void FixedUpdate()
    {
        if (FindObjectOfType<NewManager>().running)
        {

            for (int i = 0; i < times.Count; i++)
            {
                ttime = times[i];
                ttime += Time.fixedDeltaTime;
                if (ttime >= cooldown[i] && available_spells[i] > 0)
                {
                    if (FindObjectOfType<NewManager>().enemies.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        createbullet(missile[i], i);
                        ttime = 0;
                        
                    }
                }
                times[i] = ttime;
            }

            /* 
            for (int i = bullets.Count - 1; i > -1; i--)
            {
                var bullet = bullets[i];

                bullet.transform.Translate(bullet.GetComponent<NewBullets>().heading * speed_bullet[bullet.GetComponent<NewBullets>().num] * Time.fixedDeltaTime);
                float x = bullet.transform.position.x;
                float y = bullet.transform.position.y;

                if (x > topRight.x + player.transform.position.x || x < bottomLeft.x + player.transform.position.x || y > topRight.y + player.transform.position.y || y < bottomLeft.y + player.transform.position.y)
                {
                    Destroy(bullet);
                    bullets.Remove(bullet);
                }
            }
            */
            //foreach (GameObject bullet in bulletstodel) 
            //{
            //    bullets.Remove(bullet);
            //}
        }
    }
}
