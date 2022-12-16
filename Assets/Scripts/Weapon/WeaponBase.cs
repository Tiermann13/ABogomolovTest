using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] 
    private Sprite body;
    
    [SerializeField]
    private GameObject projectile;
    
    
    [SerializeField] 
    private float fireRate = 1;

    private GameObject lastProjectile;

    private void Start()
    {
        if (body)
        {
            GetComponent<SpriteRenderer>().sprite = body;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, transform.position, transform.parent.rotation);
    }
}
