using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class managerDebuffov : MonoBehaviour
{
    public List<GameObject> debuffs = new List<GameObject>(); 
    public void debuffLazeraOne(GameObject obj)
    {
        obj.GetComponent<NewEnemy>().hp -= 5;
        obj.GetComponent<NewEnemy>().speed = 0.9f * obj.GetComponent<NewEnemy>().defaultspeed;
    }

    public void FixedUpdate()
    {
        foreach (GameObject debuff in debuffs)
        {
            debuff.GetComponent<parentcd>().upd(Time.deltaTime);
        }
    }
}

