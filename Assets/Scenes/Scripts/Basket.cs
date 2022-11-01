using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Basket : MonoBehaviour
{
    private float _maxPosition = 21.5f;

    private int _countToLevelEnd = 3000;

    private bool _isLevelComplited = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BasketMotion();
    }

    private void BasketMotion()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = Mathf.Max(-_maxPosition, Mathf.Min(_maxPosition, mousePos3D.x));
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collisionWith = collision.gameObject;
        if(collisionWith.tag == "Apple")
        {
            ScoreIncrease();
            Destroy(collisionWith);
        }
    }

    private void ScoreIncrease()
    {
        GameObject scoreGo = GameObject.Find("ScoreCounter");
        TMP_Text scoreText = scoreGo.GetComponent<TMP_Text>();
        int sc = int.Parse(scoreText.text);
        sc += 100;
        scoreText.text = sc.ToString();
        if(sc >= _countToLevelEnd)
        {
            _isLevelComplited = true;
        }
        //_isLevelComplited = (sc >= _countToLevelEnd);
        //добавить второй уровень с ускорением €блони, €блока, баллы увеличить 
        //сделать ещЄ одну сцену

    }
}
