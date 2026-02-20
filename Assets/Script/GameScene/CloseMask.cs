
using System;
using System.Collections;
using UnityEngine;

public class CloseMask : MonoBehaviour
{
    public GameObject fatherObject;
    public readonly Vector3 MaxScale = new (80, 80, 0);
    public readonly Vector3 MinScale = new (0, 0, 0);

    

    private void Start()
    {
        transform.localScale = MinScale;
    }
    public void On()
    {
        StartCoroutine(Big());
    }

    private void Off()
    {
        StartCoroutine(Small());
    }


    private IEnumerator Big()
    {
        float duration = 1f;
        float elapsed = 0f;
        transform.localScale = MinScale;
    
        while (elapsed < duration)
        {
            float t = elapsed / duration;
        
            // 使用数学函数实现先慢后快
            // t*t 或 t*t*t 效果更明显
            float easeInValue = t*t; 
        
            transform.localScale = Vector3.Lerp(MinScale, MaxScale, easeInValue);
        
            elapsed += Time.deltaTime;
            yield return null;
        }
    
        transform.localScale = MaxScale;
    }
    private IEnumerator Small()
    {
        float duration = 1f;
        float elapsed = 0f;
        transform.localScale = MaxScale;  

        while (elapsed < duration)
        {
            float t = elapsed / duration;
    
            // 先快后慢（ease-out），让缩小更自然
            // 1-(1-t)^3 或简单的 1-t 线性
            float easeOutValue = 1f - Mathf.Pow(1f - t, 2f);
    
            transform.localScale = Vector3.Lerp(MaxScale, MinScale, easeOutValue);
    
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = MinScale;  // 确保最终值精确
    }

    
    
}
