
using System;
using UnityEngine;

public abstract class BaseUI<T> : MonoBehaviour where T : class
{
    private static T _instance;
    public static T instance=>_instance;
    public Camera mainCamera;

    public  void Awake()
    {
        if (_instance == null)
            _instance = this as T;
        else
        {
            Destroy(gameObject);
        }
    }
    

    public virtual void On()
    {
        gameObject.SetActive(true);
        Move();
        
    }

    public virtual void Off()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnDestroy()
    {
        if(instance == this as T)
            _instance=null;
    }

    protected virtual void Move()
    {
        if(mainCamera!=null)
            transform.position=new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y,0);

    }

    protected void OnEnable()
    {
        
        if(mainCamera==null)
            mainCamera=Camera.main;
        
    }
}
