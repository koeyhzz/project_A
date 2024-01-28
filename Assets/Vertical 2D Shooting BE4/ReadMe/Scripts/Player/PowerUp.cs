using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : RecycleObject
{

    public float moveSpeed = 2.0f;
    public float dirChangeInterval = 1.0f;
    public int dirChangeCountMax = 5;
    int dirChangeCount = 5;
    int DirChangeCount
    {
        get => dirChangeCount;
        set
        {
            animator.SetInteger("Count", dirChangeCount);  

            StopAllCoroutines();        

            if (dirChangeCount > 0 && gameObject.activeSelf) 
            {
             
                StartCoroutine(DirectionChange());         
            }
        }
    }

    Vector3 direction;
    Transform playerTransform;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        StopAllCoroutines();                

        playerTransform = GameManager.Instance.Player.transform;
        direction = Vector3.zero;            
        DirChangeCount = dirChangeCountMax; 
    }

    IEnumerator DirectionChange()
    {
        yield return new WaitForSeconds(dirChangeInterval);

        
        if (Random.value < 0.4f)
        {
            Vector2 playerToPowerUp = transform.position - playerTransform.position;    
            direction = Quaternion.Euler(0, 0, Random.Range(-90.0f, 90.0f)) * playerToPowerUp;      
        }
        else
        {
            direction = Random.insideUnitCircle;    
        }

        direction.Normalize();                                                               

        DirChangeCount--;                       
    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * direction);    // 항상 direction 방향으로 이동
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (DirChangeCount > 0 && collision.gameObject.CompareTag("Border"))   // 보더랑 부딪치면
        {
            direction = Vector2.Reflect(direction, collision.contacts[0].normal);   // 이동 방향 반사시키기
            DirChangeCount--;
        }
    }
}
