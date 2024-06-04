using UnityEngine.UI;
using UnityEngine;

public class spell_list : MonoBehaviour
{
    public GameObject gun;
    public Text spelllist;

    void Start()
    {
        spelllist.text = "";
        foreach (int spell in gun.GetComponent<gun>().available_spells)
        {
            spelllist.text += spell.ToString("0") + "\n";
        }
    }

    // Update is called once per frame
    
}
