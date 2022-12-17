using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private float health = 100.0f;
    
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
        EnemyManager.enemiesCounter--;
        Destroy(gameObject);
    }
}
