
using UnityEngine;


public class lolkek : MonoBehaviour
{
    public GameObject stats;

    public Vector3 heading;
    public float level = 1f;
    public float damage = 1; // * (0.9 + level * 0.1);
    public int num;

    public void initt(float x, float y, int num)
    {
        //
        heading.x = x;
        heading.y = y;
        heading.z = 0;
        damage = FindObjectOfType<gun>().spells_dmg[num] * GameObject.Find("Square").GetComponent<PlayerMovement>().dmgup * (1 + FindObjectOfType<gun>().available_spells[FindObjectOfType<gun>().available_spells.Count - 2]) * FindObjectOfType<gun>().available_spells[num];
    }

    

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
            Destroy(gameObject);
            FindObjectOfType<gun>().bullets.Remove(gameObject);
        }
    }
}
