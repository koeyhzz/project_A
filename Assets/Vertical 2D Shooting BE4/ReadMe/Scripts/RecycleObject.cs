using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleObject : MonoBehaviour
{
    public Action onDisable;

    protected virtual void OnEnable()
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        StopAllCoroutines();
    }

    protected virtual void OnDisable()
    {
        onDisable?.Invoke();        
    }

    
    protected IEnumerator LifeOver(float delay = 0.0f)
    {
        yield return new WaitForSeconds(delay); 
        gameObject.SetActive(false);            
    }
}
