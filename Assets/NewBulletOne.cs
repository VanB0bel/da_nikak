using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBulletOne : NewBullets
{
    // Start is called before the first frame update

    //void OnDisable()
    //{
    //    damage *= 10 * FindObjectOfType<gun>().available_spells[0];
    //}

    void FixedUpdate()
    {
        if (need_init)
        {
            speed = 4f;
            damage = 10 * GameObject.Find("Square").GetComponent<NewMovement>().dmgup * (1 + FindObjectOfType<NewGun>().available_spells[FindObjectOfType<NewGun>().available_spells.Count - 2]) * FindObjectOfType<NewGun>().available_spells[num];
            need_init = false;
        }

        standard_move();
        lifetime_destroy();
    }
}
