using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class lazer : aoe
{
    int damage, size;
    public GameObject lazerobj;
    cdForTime cd;
    public Action<GameObject> debuffLuzh;
    public void init(int damage, int size, Vector2 ddist, Vector3 cur_pos)
    {
        debuffLuzh = FindObjectOfType<managerDebuffov>().debuffLazeraOne;
        cd = gameObject.AddComponent<cdForTime>();
        float v = (float)Math.Atan(ddist.x / ddist.y);
        this.damage = damage;
        this.size = size;
        Quaternion target = Quaternion.Euler(0, 0, v);
        Instantiate(lazerobj, cur_pos, target);


    }

    public void debuff()
    {

    }

    /*public override void debuffLuzh(GameObject target)
    {
        target.GetComponent<NewEnemy>().hp -= 5;
        target.GetComponent<NewEnemy>().speed = 0.9f * target.GetComponent<NewEnemy>().defaultspeed;
    }*/
}
