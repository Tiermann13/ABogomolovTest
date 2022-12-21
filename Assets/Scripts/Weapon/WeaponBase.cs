using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] 
    private Sprite body;
    [SerializeField] 
    private GameObject projectileStartPoint;
    
    public GameObject projectile;
    
    private void Start()
    {
        if (body)
        {
            GetComponent<SpriteRenderer>().sprite = body;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, projectileStartPoint.transform.position, transform.parent.rotation);
    }
}
