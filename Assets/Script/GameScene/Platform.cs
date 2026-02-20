using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformEffector2D _platformEffector;
    public float offTime = 0.5f;
    private const int PlayerLayer = 3;

    void Start()
    {
        _platformEffector = GetComponent<PlatformEffector2D>();
    }

    private IEnumerator TurnOff()//通过取消碰撞，让玩家实现下平台
    {
        
        _platformEffector.colliderMask = ~(1 << PlayerLayer);
        yield return new WaitForSeconds(offTime);
        _platformEffector.colliderMask = ~(0);
        
    }

    public void StartTurnOff()
    {
        StartCoroutine(TurnOff());
    }
    
}
