using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 시작하자마자 계속 오른쪽으로 초속 7로 움직이게 만들기

    public float moveSpeed = 7.0f;

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * Vector2.up);
        transform.Translate(Vector2.up * Time.deltaTime * moveSpeed);
    }
}
