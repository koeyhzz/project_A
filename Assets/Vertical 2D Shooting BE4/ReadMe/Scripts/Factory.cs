using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PoolObjectType
{
    PlayerBullet = 0,   // �÷��̾��� �Ѿ�
    PowerUp,            // �Ŀ��� ������
    EnemyBoss,          // ��(����)
}

public class Factory : Singleton<Factory>
{
    Bullet bullet;

    internal void GetBullet(Vector3 position, float z)
    {
        throw new NotImplementedException();
    }
}
