using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int j = 0; j < 155555; j++)
            {
                var t = transform.GetComponent<Rigidbody>();
                var p = transform.GetComponent(typeof(Rigidbody));
                var po = transform.GetComponent("Rigidbody");
                GameObject.FindObjectOfType<Rigidbody>();

            }
            stopwatch.Stop();
            double d = stopwatch.ElapsedTicks;
        }
    }



    void Update()
    {

    }
}
