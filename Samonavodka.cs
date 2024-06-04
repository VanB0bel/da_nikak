using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Samonavodka : NewBullets
{

    int cnt = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        cnt++;
        if (need_init)
        {
            speed = 3f;
            damage = 10 * GameObject.Find("Square").GetComponent<NewMovement>().dmgup * (1 + FindObjectOfType<NewGun>().available_spells[FindObjectOfType<NewGun>().available_spells.Count - 2]) * FindObjectOfType<NewGun>().available_spells[num];
            need_init = false;
        }


        standard_move();
        lifetime_destroy();

        if (enemy == null)
        {
            return;
        }
        if (cnt == 10)
        {
            Vector3 mindist = transform.position - enemy.transform.position;
            float d = (float)Math.Sqrt(mindist[0] * mindist[0] + mindist.y * mindist.y) / 2f;
            float dx = mindist.x / d, dy = mindist.y / d;
            heading.x = -dx;
            heading.y = -dy;
            cnt = 0;
        }

    }
}
