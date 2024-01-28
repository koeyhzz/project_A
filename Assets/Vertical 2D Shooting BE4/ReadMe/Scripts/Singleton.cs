using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Component
{
    
    bool isInitialized = false;

    
    private static bool isShutdown = false;

    
    private static T instance = null;

    
    public static T Instance
    {
        get
        {
            if (isShutdown)  // ����ó���� ������
            {
                Debug.LogWarning("�̱����� �̹� �������̴�.");     // �������ϰ�
                return null;                                     // null ����
            }

            if (instance == null)    // ��ü�� ������
            {
                T singleton = FindAnyObjectByType<T>();         // �ٸ� ���� ������Ʈ�� �ش� �̱����� �ִ��� Ȯ��
                if (singleton == null)                           // �ٸ� ���� ������Ʈ���� �� �̱����� ������
                {
                    GameObject obj = new GameObject();          // �� ���� ������Ʈ �����
                    obj.name = "Singleton";                     // �̸� ������ ����
                    singleton = obj.AddComponent<T>();          // �̱��� ������Ʈ ���� �߰�
                }
                instance = singleton;   // �ٸ� ���ӿ�����Ʈ�� �ִ� �̱����̳� ���θ��� �̱����� ����
                DontDestroyOnLoad(instance.gameObject);         // ���� ����� �� ���ӿ�����Ʈ�� �������� �ʵ��� ����
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)        // ���� �̹� ��ġ�� �ٸ� �̱����� ����.
        {
            instance = this as T;   // ù��°�� ����
            DontDestroyOnLoad(instance.gameObject); // ���� ����� �� ���ӿ�����Ʈ�� �������� �ʵ��� ����
        }
        else
        {
            
            if (instance != this)    // �װ� ���ڽ��� �ƴϸ�
            {
                Destroy(this.gameObject);   // ���ڽ��� ����
            }
        }
    }

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

   
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!isInitialized)
        {
            OnPreInitialize();
        }
        if (mode != LoadSceneMode.Additive)  // additive�� �ƴҶ��� ����
        {
            OnInitialize();
        }
    }

    
    protected virtual void OnPreInitialize()
    {
        isInitialized = true;
    }

    
    protected virtual void OnInitialize()
    {
    }


    private void OnApplicationQuit()
    {
        isShutdown = true;
    }
}


// �̱����� ������ ��ü�� 1���̾�� �Ѵ�.
public class TestSingleton
{
    private static TestSingleton instance = null;

    public static TestSingleton Instance
    {
        get
        {
            if (instance == null)   // ������ �ν��Ͻ��� ������� ���� ������
            {
                instance = new TestSingleton(); // �ν��Ͻ� ����
            }
            return instance;
        }
    }

    private TestSingleton()
    {
        // ��ü�� �ߺ����� �����Ǵ� ���� �����ϱ� ���� �����ڸ� private���� �Ѵ�.(�⺻ �����ڰ� ��������� ���� ����)
    }
}
