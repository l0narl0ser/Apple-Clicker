using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Button _continueButton;

    [SerializeField]
    private Button _exitButton;

    public void Start() 
    {
        _startButton.onClick.AddListener(StartGame);
        _continueButton.onClick.AddListener(ContinueGame);
        _exitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
    public void ContinueGame() 
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
}
