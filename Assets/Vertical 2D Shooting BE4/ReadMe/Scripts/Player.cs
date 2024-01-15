using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    PlayerInputActions inputActions;

    /// <summary>
    /// 마지막으로 입력된 방향을 기록하는 변수
    /// public 맴버 변수는 인스팩터 창에서 확인이 가능하다.
    /// </summary>
    Vector3 inputDir = Vector3.zero;

    /// <summary>
    /// 플레이어의 이동속도
    /// </summary>
    public float moveSpeed = 0.01f;

    Animator anim;
    readonly int InputY_String = Animator.StringToHash("InputY");

    // InputSystem : 유니티의 새로운 입력 방식
    // Event-driven 방식 적용.

    // 이 스크립트가 포함된 게임 오브젝트가 생성 완료되면 호출된다.
    private void Awake()
    {
        inputActions = new PlayerInputActions();            // 인풋 액션 생성
        anim = GetComponent<Animator>();
    }

    // 이 스크립트가 포함된 게임 오브젝트가 활성화되면 호출된다.
    private void OnEnable()
    {
        inputActions.Player.Enable();                       // 활성화될 때 Player액션맵을 활성화
        inputActions.Player.Fire.performed += OnFire;       // Player액션맵의 Fire 액션에 OnFire함수를 연결(눌렀을 때만 연결된 함수 실행)
        inputActions.Player.Fire.canceled += OnFire;       // Player액션맵의 Fire 액션에 OnFire함수를 연결(땠을 때만 연결된 함수 실행)
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    // 이 스크립트가 포함된 게임 오브젝트가 비활성화되면 호출된다.
    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Fire.canceled -= OnFire;       // Player액션맵의 Fire 액션에 OnFire함수를 연결해제
        inputActions.Player.Fire.performed -= OnFire;       // Player액션맵의 Fire액션에서 OnFire함수를 연결해제
        inputActions.Player.Disable();                      // Player액션맵을 비활성화
    }

    

    /// <summary>
    /// Fire액션이 발동했을 때 실행 시킬 함수
    /// </summary>
    /// <param name="context">입력관련 정보가 들어있는 구조체 변수</param>
    private void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)   // 지금 입력이 눌렀다
        {
            Debug.Log("OnFire : 눌려짐");
        }
        if (context.canceled)   // 지금 입력이 떨어졌다
        {
            Debug.Log("OnFire : 떨어짐");
        }

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // scope : 변수나 함수의 사용 가능한 범위
        inputDir =context.ReadValue<Vector2>();
        //Debug.Log($"OnMove : ({dir})");

        //this.transform.position = new Vector3(1, 0, 0); // 이 게임 오브젝트의 위치를 (1,0,0)으로 보내라
        //transform.position += new Vector3(1,0,0);     // 이 게임 오브젝트의 위치를 현재 위치에서 (1,0,0)만큼 움직여라
        //transform.position += Vector3.right;

        //transform.position = (Vector3)dir;    // 이 게임 오브젝트의 위치를 현재 위치에서 inputDir 방향으로 움직여라
        
        //anim.SetFloat("InputY", inputDir.y);
        anim.SetFloat(InputY_String, inputDir.x);    
    }
    // 이 스크립트가 포함된 게임 오브젝트의 첫번째 Update함수가 실행되기 직전에 호출된다.
    private void Start()
    {
        
    }

    private void Update()
    {
        //transform.position += inputDir;      // OnMove에서 입려된 방향으로 움직이기
       
        // Time.deltaTime : 프레임간의 시간 간격(가변적)
        transform.Translate(Time.deltaTime * moveSpeed * inputDir);     // 1초당 moveSpeed만큼의 속도로 inputDir 방향으로 움직여라
    }
}
