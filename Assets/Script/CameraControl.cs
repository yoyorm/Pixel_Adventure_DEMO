using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    private Vector3 _aimPosition;
    private Vector3 _v;
    void LateUpdate()
    {
        if(player != null)
        {
            _aimPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, _aimPosition,ref _v,0.3f);
        }
    }
}
