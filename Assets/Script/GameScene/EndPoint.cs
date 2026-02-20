using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    [SerializeField] private bool active;
    
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            active = true;
            EventBus<OverUIEvent>.Publish(new OverUIEvent(true));
            _animator.SetBool(AnimatorParams.Active, active);
            BirthPointMgr.instance.NewBirthPoint(transform.position);
            GameManager.Instance.ChangeGameState(GameState.GameOver);
        }
    }
}

