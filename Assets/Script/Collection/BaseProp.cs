
using UnityEngine;

public class BaseProp : MonoBehaviour
{
    protected int ScoreValue=1;

    protected virtual void BeingCollected()
    {
        LevelManager.Instance.AddScore(ScoreValue);
        DestroyThis();
    }

    protected virtual void DestroyThis()
    {
        GameObject.Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
            BeingCollected();
    }
}
