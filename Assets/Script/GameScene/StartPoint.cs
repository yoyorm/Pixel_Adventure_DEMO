using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    
    private void Start()
    {
        BirthPointMgr.instance.NewBirthPoint(transform.position);
        GameManager.Instance.ChangeGameState(GameState.StartGame);
        
    }

    
}
