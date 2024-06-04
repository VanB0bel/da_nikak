using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewEnemy : MonoBehaviour
{
    public float speed = 2f;
    public float defaultspeed; 
    public float exp_for_kill = 10;
    public float hp = 30f;
    public float enemycnt = 0f;
    public float damage;
    public Dictionary<GameObject, cdFullTime> luzhi = new Dictionary<GameObject, cdFullTime>();
    public Dictionary<GameObject, cdFullTime> lazeri = new Dictionary<GameObject, cdFullTime>();
    public List<cdForTime> laz_debuffs = new List<cdForTime>();
    public void initt(int type)
    {
        enemycnt = FindObjectOfType<NewManager>().enemycnt;

        if (type == 0)
        {
            speed = 2f;
            exp_for_kill = 10f;
            hp = 30f;
            damage = 10f;
            hp += enemycnt * 3f;
            damage += enemycnt;
            exp_for_kill += enemycnt / 2f;
            defaultspeed = speed;
        }
        else if (type == 1)
        {
            speed = 3f;
            exp_for_kill = 5f;
            hp = 15f;
            damage = 5f;
            hp += enemycnt * 2f;
            damage += enemycnt / 2f;
            exp_for_kill += enemycnt / 4f;
            defaultspeed = speed;
        }
        if (enemycnt < 30) GetComponent<SpriteRenderer>().color -= new Color(0, enemycnt / 30, enemycnt / 30, 0);

        if (enemycnt > 30 && enemycnt < 60)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            GetComponent<SpriteRenderer>().color -= new Color((enemycnt - 30) / 30, 0, 0, 0);
        }

        if (enemycnt > 60)
        {
            GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
            GetComponent<SpriteRenderer>().color += new Color(0, (enemycnt - 60) / 30, 0, 0);
        }

    }

    public void makeDefaultSpeed(GameObject obj)
    {
        speed = defaultspeed;
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        Debug.Log("luzha111");
        if (collisionInfo.GetComponent<Collider2D>().tag == "luzha")
        {
            Debug.Log("luzha");
            cdFullTime a = gameObject.AddComponent<cdFullTime>();
            a.init(collisionInfo.gameObject.GetComponent<aoe>().cooldown, collisionInfo.gameObject.GetComponent<aoe>().debuffLuzh, makeDefaultSpeed, this.gameObject);
            luzhi.Add(collisionInfo.GetComponent<GameObject>(), a);
        }
        if (collisionInfo.GetComponent<Collider2D>().tag == "Projectile")
        {
            hp -= collisionInfo.gameObject.GetComponent<NewBullets>().damage;
        }
        if(collisionInfo.GetComponent<Collider2D>().tag == "lazer")
        {
            cdFullTime a = gameObject.AddComponent<cdFullTime>();
            a.init(collisionInfo.gameObject.GetComponent<aoe>().cooldown, collisionInfo.gameObject.GetComponent<aoe>().debuffLuzh, makeDefaultSpeed, this.gameObject);
            lazeri.Add(collisionInfo.GetComponent<GameObject>(), a);
        }
        /*if (collisionInfo.GetComponent<Collider2D>().tag == "Player")
        {

            GameObject.Find("Square").GetComponent<NewMovement>().hp -= damage;
            sc.zero(1f, ReverseSpeed, ReverseSpeed);
        }*/
    }

    void OnTriggerExit2D(Collider2D collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider2D>().tag == "luzha")
        {
            Debug.Log("luzhaexit");
            Destroy(luzhi[collisionInfo.GetComponent<GameObject>()]);
            luzhi.Remove(collisionInfo.GetComponent<GameObject>());
        }
        if(collisionInfo.GetComponent<Collider2D>().tag == "lazer")
        {
            cdForTime a = gameObject.AddComponent<cdForTime>(); 
            a.init(5f, 1f, makeDefaultSpeed, this.gameObject);
            laz_debuffs.Add(a);
            Destroy(lazeri[collisionInfo.GetComponent<GameObject>()]);
            lazeri.Remove(collisionInfo.GetComponent<GameObject>());
        }
    }

    private void FixedUpdate()
    {
        for(int i = 0; i < laz_debuffs.Count; i++)
        {
            laz_debuffs[i].upd(Time.fixedDeltaTime);
        }
    }
}
