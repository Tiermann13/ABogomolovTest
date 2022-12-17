using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private List<WeaponBase> weaponsList;
    private List<WeaponBase> weaponsListAfterInit = new List<WeaponBase>();
    
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private Slider powerBar;

    private WeaponBase currentWeapon;
    private int currentWeaponIndex = 0;
    private int nextWeaponIndex;
    private Canvas canvas;
    private float health = 100.0f;
    private float maxHealth = 100.0f;
    private float maxPower = 50.0f;
    private float power = 0.0f;
    
    void Start()
    {
        InitWeapons();
        canvas = GetComponentInChildren<Canvas>();
        UpdateHealthBar();
        UpdatePowerBar();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            currentWeapon.Fire();
        }

        if (Input.GetMouseButtonDown(2))
        {
            ChangeWeapon();
        }
        canvas.transform.rotation = Quaternion.AngleAxis(-transform.rotation.z, Vector3.forward);
    }

    private void InitWeapons()
    {
        if (weaponsList.Count == 0)
        {
            Debug.Log("EMPTY WEAPONLIST!!!");
            return;
        }
        
        foreach (WeaponBase weapon in weaponsList)
        {
            WeaponBase newWeapon = Instantiate(weapon, transform);
            weaponsListAfterInit.Add(newWeapon);
            newWeapon.gameObject.SetActive(false);
        }

        currentWeapon = weaponsListAfterInit[0];
        currentWeapon.gameObject.SetActive(true);
    }

    private void UpdateHealthBar()
    {
        healthBar.value = health / maxHealth;
    }

    private void UpdatePowerBar()
    {
        power = currentWeapon.projectile.GetComponent<ProjectileBase>().damage;
        powerBar.value = power / maxPower;
    }
    private void ChangeWeapon()
    {
        currentWeapon.gameObject.SetActive(false);
        currentWeaponIndex = weaponsListAfterInit.IndexOf(currentWeapon);
        nextWeaponIndex = (weaponsListAfterInit.Count == currentWeaponIndex + 1) ? 0 : (currentWeaponIndex + 1);
        currentWeapon = weaponsListAfterInit[nextWeaponIndex];
        currentWeapon.gameObject.SetActive(true);
        
        UpdatePowerBar();
    }

    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health > 0)
        {
            UpdateHealthBar();
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
