using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Transform[] Back;
    public float scrollingSpeed = 2.5f;
    const float BackgroundHeight = 13.6f;
    float baseLineX;

    protected virtual void Awake()
    {
        Back = new Transform[transform.childCount];  // �迭 �����
        for (int i = 0; i < Back.Length; i++)
        {
            Back[i] = transform.GetChild(i);         // �迭�� �ڽ��� �ϳ��� �ֱ�
        }

        baseLineX = transform.position.x - BackgroundHeight; // �����̵� x��ġ ���ϱ�
    }

    private void Update()
    {
        for (int i = 0; i < Back.Length; i++)
        {
            Back[i].Translate(Time.deltaTime * scrollingSpeed * -transform.up);   // �̵� ����� ��� �������� �̵� ��Ű��

            if (Back[i].position.x < baseLineX)  // ���ؼ��� �Ѿ����� Ȯ���ϰ�
            {
                MoveUnder(i);                       // �Ѿ����� ������ ������ ������
            }
        }
    }

    protected virtual void MoveRight(int index)
    {
        Back[index].Translate(BackgroundHeight * Back.Length * transform.up);   // ����ִ� ����  * ���α��� ��ŭ ���������� ������
    }
    protected virtual void MoveUnder(int index) => Back[index].Translate(BackgroundHeight * Back.Length * transform.up);   // ����ִ� ����  * ���α��� ��ŭ ���������� ������
    
}
