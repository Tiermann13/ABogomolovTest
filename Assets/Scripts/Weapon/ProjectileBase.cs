using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed;
    
    [SerializeField]
    public float damage;

    void Update()
    {
        transform.position += transform.up * projectileSpeed * Time.deltaTime;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("ApplyDamage", damage);
        }
        
        Debug.Log("BABAH");
        Explode();
    }

    void Explode()
    {
        Destroy(gameObject);
    }
}
