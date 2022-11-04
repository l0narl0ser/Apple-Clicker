using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField]
    private GameObject _applePrefab;

    [SerializeField]
    private float secondsBetweenAppleDrops = 1f;

    public float speed = 1f;
    public float leftAndRightEdge = 15;
    public float changeToChangeDirection = 0.1f;

    void Start()
    {
        Invoke("AppleDrop", 2f); //вызов метода через промежуток времени
    }


    void Update()
    {
        MovingAppleTree();
        ChangeDirection();
    }

    private void FixedUpdate()
    {
        RandonChangeDirection();
    }
    //движение дерева
    void MovingAppleTree()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }

    //движение с ограничением экрана
    void ChangeDirection()
    {
        Vector3 pos = transform.position;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }
    //движение по вероятности
    void RandonChangeDirection()
    {
        if(Random.value < changeToChangeDirection)
        {
            speed *= -1;
        }
    }

    void AppleDrop()
    {
        
        GameObject apple = Instantiate<GameObject>(_applePrefab); //создали объект яблоко

        apple.transform.SetParent(transform);
       
        apple.transform.position = transform.position; //позиция того объекта, к которому привязан скрипт
        Invoke("AppleDrop", secondsBetweenAppleDrops); //рекурсия
    }
}
