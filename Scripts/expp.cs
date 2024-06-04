using UnityEngine;
using UnityEngine.UI;

public class expp : MonoBehaviour
{
    public GameObject player;
    public Text curexp;

    // Update is called once per frame
    void Update()
    {
        curexp.text = player.GetComponent<PlayerMovement>().exp.ToString("0");
    }
}
