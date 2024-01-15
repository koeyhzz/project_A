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
        Back = new Transform[transform.childCount];  // 배열 만들고
        for (int i = 0; i < Back.Length; i++)
        {
            Back[i] = transform.GetChild(i);         // 배열에 자식을 하나씩 넣기
        }

        baseLineX = transform.position.x - BackgroundHeight; // 기준이될 x위치 구하기
    }

    private void Update()
    {
        for (int i = 0; i < Back.Length; i++)
        {
            Back[i].Translate(Time.deltaTime * scrollingSpeed * -transform.up);   // 이동 대상을 계속 왼쪽으로 이동 시키기

            if (Back[i].position.x < baseLineX)  // 기준선을 넘었는지 확인하고
            {
                MoveUnder(i);                       // 넘었으면 오른쪽 끝으로 보내기
            }
        }
    }

    protected virtual void MoveRight(int index)
    {
        Back[index].Translate(BackgroundHeight * Back.Length * transform.up);   // 들어있는 개수  * 가로길이 만큼 오른쪽으로 보내기
    }
    protected virtual void MoveUnder(int index) => Back[index].Translate(BackgroundHeight * Back.Length * transform.up);   // 들어있는 개수  * 가로길이 만큼 오른쪽으로 보내기
    
}
