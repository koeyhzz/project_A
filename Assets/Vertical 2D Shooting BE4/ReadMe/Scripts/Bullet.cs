using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �������ڸ��� ��� ���������� �ʼ� 7�� �����̰� �����

    public float moveSpeed = 7.0f;

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * Vector2.up);
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }
}
