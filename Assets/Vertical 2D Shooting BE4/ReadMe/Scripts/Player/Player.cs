using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    PlayerInputActions inputActions;

    IEnumerator fireCoroutine;
    Transform[] fireTransforms;
    public float fireInterval = 0.5f;
    int score = 0;

    Rigidbody2D rigid2d;
    SpriteRenderer spriteRenderer;

    Vector3 inputDir = Vector3.zero;

    
    public float moveSpeed = 0.01f;

    Animator anim;
    readonly int InputY_String = Animator.StringToHash("Input");

    public Action<int> onLifeChange;
    public Action<int> onDie;
    public float invincibleTime = 2.0f;

    private void Awake()
    {
        inputActions = new PlayerInputActions();      
        anim = GetComponent<Animator>();  
        rigid2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Transform fireRoot = transform.GetChild(0);  
        //for (int i = 0; i < fireTransforms.Length; i++)
        //{
        //    fireTransforms[i] = fireRoot.GetChild(i);
        //}
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();                     
        inputActions.Player.Fire.performed += OnFireStart;      
        inputActions.Player.Fire.canceled += OnFireEnd;      
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Fire.canceled -= OnFireEnd;      
        inputActions.Player.Fire.performed -= OnFireStart;       
        inputActions.Player.Disable();                     
    }


    private const float FireAngle = 30.0f;


    private void OnFireStart(InputAction.CallbackContext context)
    {
        StartCoroutine(fireCoroutine);
    }

    private void OnFireEnd(InputAction.CallbackContext _)
    {
        StopCoroutine(fireCoroutine);  
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>();
        anim.SetFloat(InputY_String, inputDir.x);
    }

    private void Start()
    {

    }

    private void Update()
    {
        transform.Translate(Time.deltaTime * moveSpeed * inputDir);     
    }
  
}

