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
        Invoke("AppleDrop", 2f); //����� ������ ����� ���������� �������
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
    //�������� ������
    void MovingAppleTree()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }

    //�������� � ������������ ������
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
    //�������� �� �����������
    void RandonChangeDirection()
    {
        if(Random.value < changeToChangeDirection)
        {
            speed *= -1;
        }
    }

    void AppleDrop()
    {
        
        GameObject apple = Instantiate<GameObject>(_applePrefab); //������� ������ ������

        apple.transform.SetParent(transform);
       
        apple.transform.position = transform.position; //������� ���� �������, � �������� �������� ������
        Invoke("AppleDrop", secondsBetweenAppleDrops); //��������
    }
}
