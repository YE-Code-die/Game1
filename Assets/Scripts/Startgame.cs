using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Startgame : MonoBehaviour
{
    // Start is called before the first frame update
    public static int count = 0;
    private void Start()
    {
        Cursor.visible = true;
    }
    public void SinglePlayer()
    {
        SceneManager.LoadScene("mainGame");
    }

    public void MultiPlayer()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenus");
    }
    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
