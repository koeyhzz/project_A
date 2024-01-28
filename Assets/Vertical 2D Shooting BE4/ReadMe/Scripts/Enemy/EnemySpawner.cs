using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 생성할 적 프리팹
    public float spawnInterval = 2f; // 적 생성 간격
    public float speed = 5f; // 적 이동 속도

    void Start()
    {
        // 일정 간격으로 적을 생성하는 함수 호출
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void Update()
    {
        // 적을 아래로 이동시킴
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // 적이 화면 아래로 벗어나면 파괴
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        // 적 생성
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-5f, 5f), 7f, 0f), Quaternion.identity);
    }
}