using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    public float speed = 1f;
    public float leftAndRightEdge = 15;
    public float changeToChangeDirection = 0.1f;
    void Start()
    {

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
}
