using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    public float health = 100.0f;

    public delegate void Died(Enemy gameObject);

    public event Died OnDied;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out ProjectileBase bullet))
        {
            ApplyDamage(bullet.damage);
        }
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            return;
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        OnDied?.Invoke(this);
    }
}
