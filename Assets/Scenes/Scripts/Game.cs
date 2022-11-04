using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField]
    private GameObject _basketPrefab;

    [SerializeField]
    private int _numBasket = 3;

    [SerializeField]
    private float _basketBootomY = -14f;

    [SerializeField]
    private float _basketSpacingY = 2f;

    List<GameObject> basketList;

    private int _highScore = 0;

    public int _countToLevelEnd = 600;

    public bool _isLevelComplited = false;


    //загружает очки
    private void Awake()
    {
        LoadScore();
    }

    //создает корзины
    void Start()
    {
        LoadScore();

        basketList = new List<GameObject>();

        for (int i = 0; i < _numBasket; i++)
        {
            GameObject tbasketGo = Instantiate<GameObject>(_basketPrefab);
            Vector3 pos = Vector3.zero; //(0,0,0)
            pos.y = _basketBootomY + (_basketSpacingY * i);
            tbasketGo.transform.position = pos;
            basketList.Add(tbasketGo);
        }
    }

    //уд€л€ет все €блоки
    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject item in tAppleArray)
        {
            Destroy(item);
        }

        //удал€ет корзины
        int basketIndex = basketList.Count - 1;
        GameObject tbasketGo = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tbasketGo);

        
        if (basketList.Count == 0)
        {
            SaveScore();
            SceneManager.LoadScene("Level1");
        }
    }

    public void SaveScore()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        TMP_Text scoreText = scoreGo.GetComponent<TMP_Text>();
        if (_highScore < int.Parse(scoreText.text))
        {
            _highScore = int.Parse(scoreText.text);
            PlayerPrefs.SetInt("HighScore", _highScore);

            if(_highScore > _countToLevelEnd)
            {
                SceneManager.LoadScene("Level2");
            }
        }
    }

    private void LoadScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            _highScore = 0;
        }

        GameObject scoreGo = GameObject.Find("HighScore");
        TMP_Text scoreText = scoreGo.GetComponent<TMP_Text>();
        scoreText.text = "HighScore: " + _highScore;

        scoreText = GameObject.Find("ScoreCounter").GetComponent<TMP_Text>();
        scoreText.text = "0";

    }

    public void ScoreIncrease()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        TMP_Text scoreText = scoreGo.GetComponent<TMP_Text>();
        int sc = int.Parse(scoreText.text);
        sc += 100;
        scoreText.text = sc.ToString();
        if (sc >= _countToLevelEnd)
        {
            _isLevelComplited = true;
            SceneManager.LoadScene("Level2");
        }
        //_isLevelComplited = (sc >= _countToLevelEnd); вместо услови€ 
        //добавить второй уровень с ускорением €блони, €блока, баллы увеличить 
        //сделать ещЄ одну сцену

    }
    //public void OnApplicationPause(bool pause)
    //{
    //    SceneManager.LoadScene("CreateMenu");
    //    Time.timeScale = 1f;
    //}
}