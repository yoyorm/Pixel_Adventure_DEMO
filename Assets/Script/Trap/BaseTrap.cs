
using UnityEngine;

public class BaseTrap : MonoBehaviour,IDamageable
{
    protected float _hp;
    protected float _damage;
    private Rigidbody2D _playerRb;
    public float Hp => _hp;

    public float Damage => _damage;

    

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        StartAttack(other);
    }

    public virtual void TakeDamage(float damage)
    {
        
    }

    protected virtual void StartAttack(Collider2D other)//识别玩家对象，增加受击推力
    {
        IDamageable enemy = other.gameObject.GetComponent<IDamageable>();
        if (enemy != null&&other.CompareTag("Player"))
        {
            _playerRb=other.gameObject.GetComponent<Rigidbody2D>();
            PlayerControl player = other.gameObject.GetComponent<PlayerControl>();
            StartCoroutine(player.OffPlayerControl());//短暂关闭玩家移动输入
            _playerRb.AddForce(new Vector2(other.transform.position.x-transform.position.x, other.transform.position.y-transform.position.y)*15, ForceMode2D.Impulse);
            Attack(enemy,Damage);
        }
    }

    public virtual void Attack(IDamageable enemy, float damage)//触发伤害
    {
        enemy.TakeDamage(Damage);
    }

    public virtual void Death()
    {
       Destroy(gameObject);
    }
}
