using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_button : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
