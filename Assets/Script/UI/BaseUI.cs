
using System;
using UnityEngine;

public abstract class BaseUI<T> : MonoBehaviour where T : class
{
    private static T _instance;
    public static T instance=>_instance;

    private void Awake()
    {
        _instance = this as T;
    }

    private void Start()
    {
        Init();
    }
    protected virtual void Init(){}

    public virtual void On()
    {
        gameObject.SetActive(true);
    }

    public virtual void Off()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        if(instance == this as T)
            _instance=null;
    }
}
