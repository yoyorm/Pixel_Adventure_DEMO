using System;
using UnityEngine;

public class PlayerObject : MonoBehaviour,IDamageable
{
    public float maxHp = 10;
    [SerializeField]
    private float hp;
    [SerializeField]
    private float damage = 0;
    
    
    public float Hp { get=>hp;}
    public float Damage { get=>damage;}
    
    public event Action onDamaged;
    private Rigidbody2D rb;

    private void Start()
    {
        hp = maxHp;
        rb=GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float d)
    {
        hp-=d;
        onDamaged?.Invoke();
        if (hp <= 0)
        {
            Death();
        }
    }

    public void Attack(IDamageable enemy, float d)
    {
        
    }

    public void Death()
    {
        hp = maxHp;
        rb.velocity = Vector2.zero;
        transform.position = BirthPointMgr.instance.ReadBirthPoint();
    }
}
