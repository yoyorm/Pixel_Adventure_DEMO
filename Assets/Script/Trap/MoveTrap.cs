using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrap : MonoBehaviour
{
    public enum TrapType
    {
        Line
    };
    public TrapType trapType;
    public  float size;
    public float speed;
    
    private int _dir = 1;
    private float _size;

    private void Update()
    {
        switch (trapType)
        {
            case TrapType.Line:
            {
                LineMovement();
                break;
            }
        }
    }

    private void LineMovement()
    {
        if(Time.timeScale!=0)
        {
            if (_size > 0)
            {
                gameObject.transform.Translate(Vector2.left * (speed * _dir * 0.02f));
                _size -= Time.unscaledDeltaTime;
            }
            else
            {
                _size = size;
                _dir = -_dir;
            }
        }
    }

    MoveTrap()
    {
        _size = size;
    }
}
