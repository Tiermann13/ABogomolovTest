using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAndAttack : MonoBehaviour
{
    [SerializeField] 
    private float speed = 2.0f;
    
    [SerializeField] 
    private GameObject projectileStartPoint;
    
    [SerializeField] 
    private float cooldown = 5.0f;
    
    [SerializeField]
    private GameObject projectile;
    
    private GameObject player;
    private float cooldownTimer;

   void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(!player) return;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        FireWithDelay();
    }

    private void FireWithDelay()
    {
        cooldownTimer -= Time.deltaTime;

        if(cooldownTimer > 0) return;

        cooldownTimer = cooldown;
        Instantiate(projectile, projectileStartPoint.transform.position, transform.rotation);
    }
}
