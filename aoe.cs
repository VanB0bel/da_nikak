using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class aoe : MonoBehaviour
{
    float x, y, r;
    public float cooldown;
    Vector3 pos;
    bool active = false;

    // Start is called before the first frame update
   

   virtual public void debuffLuzh(GameObject target) 
    {
        target.GetComponent<NewEnemy>().hp -= 1;
        target.GetComponent<NewEnemy>().speed = 0.5f * target.GetComponent<NewEnemy>().defaultspeed;
    }
}
