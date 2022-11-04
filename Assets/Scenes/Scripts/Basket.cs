using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Basket : MonoBehaviour
{
    private float _maxPosition = 21.5f;

    private Game game;
    void Start()
    {
        game = GameObject.Find("Game").GetComponent<Game>();
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
            game.ScoreIncrease();

            if(game._isLevelComplited)
            {
                game.SaveScore();
             
            }
        }
        Destroy(collisionWith);
    }

}
