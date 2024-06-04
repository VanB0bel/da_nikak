using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.U2D;
using UnityEngine.UIElements;
using UnityEditor.SceneManagement;

public class EnemyOne : NewEnemy
{
    cd2times sc;
    bool created = false;
    int direction = 1;

    void FixedUpdate()
    {
        if (FindObjectOfType<NewManager>().running)
        {
            
            if (!created)
            {
                sc = gameObject.AddComponent<cd2times>();
                created = true;
            }
            sc.upd(Time.fixedDeltaTime);
            var heading = GameObject.Find("Square").transform.position - transform.position;
            float d = (float)Math.Sqrt(heading[0] * heading[0] + heading.y * heading.y) / speed;
            float dx = heading.x / d, dy = heading.y / d;
            Vector2 move;
            move.x = dx; move.y = dy;
            transform.Translate(move * speed * Time.deltaTime * direction);
            if (hp <= 0)
            {
                Destroy(gameObject);
                FindObjectOfType<NewManager>().enemies.Remove(gameObject);
                GameObject.Find("Square").GetComponent<NewMovement>().exp += exp_for_kill;
            }
        }
    }

    public void ReverseSpeed()
    {
        this.direction *= -1;
    }
   
   


    
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            GameObject.Find("Square").GetComponent<NewMovement>().hp -= damage;
            sc.init(0.3f, ReverseSpeed, ReverseSpeed);
        }
    }
}
