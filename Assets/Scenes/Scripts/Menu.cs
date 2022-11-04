using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame() 
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level1");
    }
    public void NextLevel() 
    {
        SceneManager.LoadScene("Level2");
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
}
