using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyTwo : NewEnemy
{
    bool need_to_heading = true;
    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    Vector2 move;
    float lifetime = 3.5f;

    
    void FixedUpdate()
    {
        if (FindObjectOfType<NewManager>().running)
        {
            lifetime -= Time.deltaTime;
            if (need_to_heading)
            {
                var heading = GameObject.Find("Square").transform.position - transform.position;
                float d = (float)Math.Sqrt(heading[0] * heading[0] + heading.y * heading.y) / speed;
                float dx = heading.x / d, dy = heading.y / d;
                
                move.x = dx; move.y = dy;
                need_to_heading = false;
            }
            if (UnityEngine.Random.Range(0, 75) == 0)
            {
                need_to_heading = true;
            }
            transform.Translate(move * speed * Time.deltaTime);
            if (hp <= 0)
            {
                Destroy(gameObject);
                FindObjectOfType<NewManager>().enemies.Remove(gameObject);
                GameObject.Find("Square").GetComponent<NewMovement>().exp += exp_for_kill;
            }
            if (lifetime == 0)
            {
                Destroy(gameObject);
                FindObjectOfType<NewManager>().enemies.Remove(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider2D>().tag == "Projectile")
        {
            hp -= collisionInfo.gameObject.GetComponent<NewBullets>().damage;
        }
        if (collisionInfo.GetComponent<Collider2D>().tag == "Player")
        {
            GameObject.Find("Square").GetComponent<NewMovement>().hp -= damage;
        }
    }
    
}
