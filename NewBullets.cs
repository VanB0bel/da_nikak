
using UnityEngine;

public class NewBullets : MonoBehaviour
{
    public GameObject stats;

    public Vector3 heading;

    public float level = 1f;
    public float damage = 1f; // * (0.9 + level * 0.1);
    public float speed = 1f;
    public float lifetime = 1.5f;
    float lifecnt;

    public int num;
    public GameObject enemy;
    public bool need_init = true;


    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    void Awake()
    {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        topRight.x *= 1.1f; topRight.y *= 1.1f; // da hz

        Vector3 dv = topRight;
        dv.x *= 0.1f; dv.y *= 0.1f;
        dv.z = 0;
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)) - dv; // 
    }

    protected void standard_move()
    {
        if (FindObjectOfType<NewManager>().running)
        {
            transform.Translate(heading * speed * Time.fixedDeltaTime);
        }
    }

    protected void lifetime_destroy()
    {
        lifecnt += Time.deltaTime;
        if (lifecnt >= lifetime)
        {
            Destroy(gameObject);
            FindObjectOfType<NewGun>().bullets.Remove(gameObject);

        }
    }

    public void initt(float x, float y, int num, GameObject enemy_in)
    {
        //
        heading.x = x;
        heading.y = y;
        heading.z = 0;
        enemy = enemy_in;
        //damage = FindObjectOfType<NewGun>().spells_dmg[num] * GameObject.Find("Square").GetComponent<NewMovement>().dmgup * (1 + FindObjectOfType<NewGun>().available_spells[FindObjectOfType<NewGun>().available_spells.Count - 2]) * FindObjectOfType<NewGun>().available_spells[num];
    }



    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if (collisionInfo.GetComponent<Collider2D>().tag == "Enemy")
        {
            Destroy(gameObject);
            FindObjectOfType<NewGun>().bullets.Remove(gameObject);
        }
    }
}
