using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class supershtuka : MonoBehaviour
{
    public float speed = 2f;
    public float exp_for_kill = 10;
    public float hp = 30f;
    public float enemycnt = 0f;
    public float damage;

    public void initt()
    {
        exp_for_kill = 10f;
        hp = 30f;
        damage = 10f;
        enemycnt = FindObjectOfType<GameManager>().enemycnt;
        hp += enemycnt * 3;
        damage += enemycnt;
        exp_for_kill += enemycnt / 2;
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


    void Update()
    {
        if (FindObjectOfType<GameManager>().running)
        {
            var heading = GameObject.Find("Square").transform.position - transform.position;
            float d = (float)Math.Sqrt(heading[0] * heading[0] + heading.y * heading.y) / speed;
            float dx = heading.x / d, dy = heading.y / d;
            Vector2 move;
            move.x = dx; move.y = dy;
            transform.Translate(move * speed * Time.deltaTime);
            if (hp <= 0)
            {
                Destroy(gameObject);
                FindObjectOfType<GameManager>().enemies.Remove(gameObject);
                GameObject.Find("Square").GetComponent<PlayerMovement>().exp += exp_for_kill;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Projectile")
        {
            hp -= collisionInfo.gameObject.GetComponent<lolkek>().damage;
        }
        if (collisionInfo.collider.tag == "Player")
        {
            GameObject.Find("Square").GetComponent<PlayerMovement>().hp -= damage;
        }
    }
}
