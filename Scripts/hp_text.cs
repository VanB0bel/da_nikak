using UnityEngine.UI;
using UnityEngine;

public class hp_text : MonoBehaviour
{
    public GameObject player;
    public Text curhp;

    // Update is called once per frame
    void Update()
    {
        curhp.text = player.GetComponent<NewMovement>().hp.ToString("0") + '/' + player.GetComponent<NewMovement>().max_hp.ToString("0");
    }
}
