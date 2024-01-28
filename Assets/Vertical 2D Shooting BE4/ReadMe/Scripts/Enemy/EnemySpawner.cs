using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �� ������
    public float spawnInterval = 2f; // �� ���� ����
    public float speed = 5f; // �� �̵� �ӵ�

    void Start()
    {
        // ���� �������� ���� �����ϴ� �Լ� ȣ��
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void Update()
    {
        // ���� �Ʒ��� �̵���Ŵ
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // ���� ȭ�� �Ʒ��� ����� �ı�
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    void SpawnEnemy()
    {
        // �� ����
        GameObject enemy = Instantiate(enemyPrefab, new Vector3(Random.Range(-5f, 5f), 7f, 0f), Quaternion.identity);
    }
}