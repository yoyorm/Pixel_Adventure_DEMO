using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidPoint : MonoBehaviour
{
    [SerializeField]
    bool active = false;
    
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")&& !active)
        {
            active = true;
            _animator.SetBool("Active", true);
            BirthPointMgr.instance.NewBirthPoint(transform.position);
        }
    }
}
