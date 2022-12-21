using System.Collections;
using UnityEngine;

public class FireByTimer : MonoBehaviour
{
    [SerializeField] 
    private GameObject projectileStartPoint;
    
    [SerializeField] 
    private float delay = 2.0f;
    
    [SerializeField]
    private GameObject projectile;
    
    void Start()
    {
        StartCoroutine("Fire");
    }
 
    IEnumerator Fire()
    {
        for (; ; )
        {
            CreateProjectile();
            yield return new WaitForSeconds(delay);
        }
    }
 
    void CreateProjectile()
    {
        Instantiate(projectile, projectileStartPoint.transform.position, transform.rotation);
    }
}
