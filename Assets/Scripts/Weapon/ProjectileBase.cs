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
        Destroy(gameObject);
    }
}
