using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBulletDva : NewBullets
{
    // Start is called before the first frame update


    //void OnDisable() // nomer dva
    //{
    //    damage *= 5 * FindObjectOfType<gun>().available_spells[1];
    //}

    void FixedUpdate()
    {
        if (need_init)
        {
            speed = 3f;
            damage = 3 * GameObject.Find("Square").GetComponent<NewMovement>().dmgup * (1 + FindObjectOfType<NewGun>().available_spells[FindObjectOfType<NewGun>().available_spells.Count - 2]) * FindObjectOfType<NewGun>().available_spells[num];
            need_init = false;
        }

        standard_move();
        lifetime_destroy();
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
    }
}
