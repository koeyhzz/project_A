using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bullet : RecycleObject
{
    public float moveSpeed = 7.0f;

    
    public float lifeTime = 10.0f;

    

    protected override void OnEnable()
    {
        base.OnEnable();
        StartCoroutine(LifeOver(lifeTime));
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * Vector2.up);    
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        gameObject.SetActive(false);    
    }
}