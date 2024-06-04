using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;


public class super_button : MonoBehaviour
{
    public GameObject player;
    public Text curspell;
    public GameObject gun;
    public List<int> availableSpells;
    public int cs;
    public Text spelllist;

    

    public void initt(int a) 
    {
        availableSpells = FindObjectOfType<gun>().available_spells;
        cs = a;
        curspell.text = cs.ToString();

    }

    public void bababa()
    {
        Debug.Log(cs);
        availableSpells[cs] += 1;
        FindObjectOfType<GameManager>().running = true;
        foreach (GameObject but in GameObject.FindGameObjectsWithTag("lvlbutton")) 
        {
            but.gameObject.SetActive(false);
        }
        spelllist.text = "";
        foreach (int spell in availableSpells)
        {
            spelllist.text += spell.ToString("0") + "\n";
        }
    }
}
