using UnityEngine;

public class Player : MonoBehaviour
{
    private float health = 100.0f;
    public float maxHealth = 100.0f;
   
    public delegate void HealthChanged(float health);
    public event HealthChanged OnHealthChanged;
  
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
            OnHealthChanged?.Invoke(health);
            return;
        }
        else
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
