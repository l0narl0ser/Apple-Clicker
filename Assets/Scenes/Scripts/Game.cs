using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        for (int i = 0; i < _numBasket; i++)
        {
            GameObject tbasketGo = Instantiate<GameObject>(_basketPrefab);
            Vector3 pos = Vector3.zero; //(0,0,0)
            pos.y = _basketBootomY + (_basketSpacingY * i);
            tbasketGo.transform.position = pos;
        }
    }



    void Update()
    {

    }
}
