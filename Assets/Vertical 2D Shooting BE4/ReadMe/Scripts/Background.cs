using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    Transform[] Back;
    public float scrollingSpeed = 2.5f;
    const float BackgroundLength = 10.0f;
    float baseLineY;

    protected virtual void Awake()
    {
        Back = new Transform[transform.childCount];  // �迭 �����
        for (int i = 0; i < Back.Length; i++)
        {
            Back[i] = transform.GetChild(i);         // �迭�� �ڽ��� �ϳ��� �ֱ�
        }

        baseLineY = transform.position.y - BackgroundLength; // �����̵� x��ġ ���ϱ�
    }

    private void Update()
    {
        for (int i = 0; i < Back.Length; i++)
        {
            Back[i].Translate(Time.deltaTime * scrollingSpeed * -transform.up);   // �̵� ����� ��� �������� �̵� ��Ű��

            if (Back[i].position.y < baseLineY)  // ���ؼ��� �Ѿ����� Ȯ���ϰ�
            {
                MoveUp(i);                       // �Ѿ����� ������ ������ ������
            }
        }
    }

    protected virtual void MoveUp(int index)
    {
        Back[index].Translate(BackgroundLength * Back.Length * transform.up);   // ����ִ� ����  * ���α��� ��ŭ ���������� ������
    }
    
    
}
