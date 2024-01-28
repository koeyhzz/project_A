using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum PoolObjectType
{
    PlayerBullet = 0,   // 플레이어의 총알
    PowerUp,            // 파워업 아이템
    EnemyBoss,          // 적(보스)
}

public class Factory : Singleton<Factory>
{
    Bullet bullet;

    internal void GetBullet(Vector3 position, float z)
    {
        throw new NotImplementedException();
    }
}
