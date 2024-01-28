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
            if (isShutdown)  // 종료처리에 들어갔으면
            {
                Debug.LogWarning("싱글톤은 이미 삭제중이다.");     // 경고출력하고
                return null;                                     // null 리턴
            }

            if (instance == null)    // 객체가 없으면
            {
                T singleton = FindAnyObjectByType<T>();         // 다른 게임 오브젝트에 해당 싱글톤이 있는지 확인
                if (singleton == null)                           // 다른 게임 오브젝트에도 이 싱글톤이 없으면
                {
                    GameObject obj = new GameObject();          // 빈 게임 오브젝트 만들고
                    obj.name = "Singleton";                     // 이름 지정한 다음
                    singleton = obj.AddComponent<T>();          // 싱글톤 컴포넌트 만들어서 추가
                }
                instance = singleton;   // 다른 게임오브젝트에 있는 싱글톤이나 새로만든 싱글톤을 저장
                DontDestroyOnLoad(instance.gameObject);         // 씬이 사라질 때 게임오브젝트가 삭제되지 않도록 설정
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)        // 씬에 이미 배치된 다른 싱글톤이 없다.
        {
            instance = this as T;   // 첫번째를 저장
            DontDestroyOnLoad(instance.gameObject); // 씬이 사라질 때 게임오브젝트가 삭제되지 않도록 설정
        }
        else
        {
            
            if (instance != this)    // 그게 나자신이 아니면
            {
                Destroy(this.gameObject);   // 나자신을 삭제
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
        if (mode != LoadSceneMode.Additive)  // additive가 아닐때만 실행
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


// 싱글톤은 무조건 객체가 1개이어야 한다.
public class TestSingleton
{
    private static TestSingleton instance = null;

    public static TestSingleton Instance
    {
        get
        {
            if (instance == null)   // 이전에 인스턴스가 만들어진 적이 없으면
            {
                instance = new TestSingleton(); // 인스턴스 생성
            }
            return instance;
        }
    }

    private TestSingleton()
    {
        // 객체가 중복으로 생성되는 것을 방지하기 위해 생성자를 private으로 한다.(기본 생성자가 만들어지는 것을 방지)
    }
}
