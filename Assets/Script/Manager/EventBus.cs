using System;
using UnityEngine;


public static class EventBus<T> where T : class 
{
    public static event Action<T> onEvent;
    private static T _cachedEvent;

    public static void Publish(T  value)
    {
        Debug.Log("事件触发: "+value);
        _cachedEvent = value;
        onEvent?.Invoke(value);
    }

    public static void Subscribe(Action<T> action)
    {
        onEvent += action;
    }

    public static void Unsubscribe(Action<T> action)
    {
        onEvent -= action;
    }

    public static T GetEvent()
    {
        return _cachedEvent;
    }
}

// public static class EventBus<T1, T2> where T1 : struct where T2 : class
// {
//     public static event Action<T1, T2> onEvent;
//
//     public static void Publish(T1 value1, T2 value2)
//     {
//         
//         onEvent?.Invoke(value1, value2);
//     }
//
//     public static void Subscribe(Action<T1, T2> action)
//     {
//         onEvent += action;
//     }
//
//     public static void Unsubscribe(Action<T1, T2> action)
//     {
//         onEvent -= action;
//     }
// }
