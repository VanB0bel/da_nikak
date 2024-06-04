using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item_odin : MonoBehaviour
{
    // Start is called before the first frame update
    public void initt()
    {

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        Debug.Log("aaa");
        if (collisionInfo.collider.tag == "Player")
        {
            Debug.Log("bbb");
            Destroy(gameObject);
            FindObjectOfType<Items>().items_.Remove(gameObject);
            GameObject.Find("Square").GetComponent<PlayerMovement>().hp += 100;
        }

    }
}
