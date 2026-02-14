using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    float Hp { get;}
    float Damage { get;}

    void TakeDamage(float damage);
    
    
    void Attack(IDamageable enemy,float damage);
    void Death();
}
