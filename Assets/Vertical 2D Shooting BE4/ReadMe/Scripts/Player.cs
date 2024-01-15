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
    /// ���������� �Էµ� ������ ����ϴ� ����
    /// public �ɹ� ������ �ν����� â���� Ȯ���� �����ϴ�.
    /// </summary>
    Vector3 inputDir = Vector3.zero;

    /// <summary>
    /// �÷��̾��� �̵��ӵ�
    /// </summary>
    public float moveSpeed = 0.01f;

    Animator anim;
    readonly int InputY_String = Animator.StringToHash("InputY");

    // InputSystem : ����Ƽ�� ���ο� �Է� ���
    // Event-driven ��� ����.

    // �� ��ũ��Ʈ�� ���Ե� ���� ������Ʈ�� ���� �Ϸ�Ǹ� ȣ��ȴ�.
    private void Awake()
    {
        inputActions = new PlayerInputActions();            // ��ǲ �׼� ����
        anim = GetComponent<Animator>();
    }

    // �� ��ũ��Ʈ�� ���Ե� ���� ������Ʈ�� Ȱ��ȭ�Ǹ� ȣ��ȴ�.
    private void OnEnable()
    {
        inputActions.Player.Enable();                       // Ȱ��ȭ�� �� Player�׼Ǹ��� Ȱ��ȭ
        inputActions.Player.Fire.performed += OnFire;       // Player�׼Ǹ��� Fire �׼ǿ� OnFire�Լ��� ����(������ ���� ����� �Լ� ����)
        inputActions.Player.Fire.canceled += OnFire;       // Player�׼Ǹ��� Fire �׼ǿ� OnFire�Լ��� ����(���� ���� ����� �Լ� ����)
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    // �� ��ũ��Ʈ�� ���Ե� ���� ������Ʈ�� ��Ȱ��ȭ�Ǹ� ȣ��ȴ�.
    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Fire.canceled -= OnFire;       // Player�׼Ǹ��� Fire �׼ǿ� OnFire�Լ��� ��������
        inputActions.Player.Fire.performed -= OnFire;       // Player�׼Ǹ��� Fire�׼ǿ��� OnFire�Լ��� ��������
        inputActions.Player.Disable();                      // Player�׼Ǹ��� ��Ȱ��ȭ
    }

    

    /// <summary>
    /// Fire�׼��� �ߵ����� �� ���� ��ų �Լ�
    /// </summary>
    /// <param name="context">�Է°��� ������ ����ִ� ����ü ����</param>
    private void OnFire(InputAction.CallbackContext context)
    {
        if(context.performed)   // ���� �Է��� ������
        {
            Debug.Log("OnFire : ������");
        }
        if (context.canceled)   // ���� �Է��� ��������
        {
            Debug.Log("OnFire : ������");
        }

    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // scope : ������ �Լ��� ��� ������ ����
        inputDir =context.ReadValue<Vector2>();
        //Debug.Log($"OnMove : ({dir})");

        //this.transform.position = new Vector3(1, 0, 0); // �� ���� ������Ʈ�� ��ġ�� (1,0,0)���� ������
        //transform.position += new Vector3(1,0,0);     // �� ���� ������Ʈ�� ��ġ�� ���� ��ġ���� (1,0,0)��ŭ ��������
        //transform.position += Vector3.right;

        //transform.position = (Vector3)dir;    // �� ���� ������Ʈ�� ��ġ�� ���� ��ġ���� inputDir �������� ��������
        
        //anim.SetFloat("InputY", inputDir.y);
        anim.SetFloat(InputY_String, inputDir.x);    
    }
    // �� ��ũ��Ʈ�� ���Ե� ���� ������Ʈ�� ù��° Update�Լ��� ����Ǳ� ������ ȣ��ȴ�.
    private void Start()
    {
        
    }

    private void Update()
    {
        //transform.position += inputDir;      // OnMove���� �Է��� �������� �����̱�
       
        // Time.deltaTime : �����Ӱ��� �ð� ����(������)
        transform.Translate(Time.deltaTime * moveSpeed * inputDir);     // 1�ʴ� moveSpeed��ŭ�� �ӵ��� inputDir �������� ��������
    }
}
