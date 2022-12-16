using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private List<WeaponBase> weaponsList;
    private List<WeaponBase> weaponsListAfterInit = new List<WeaponBase>();

    private WeaponBase currentWeapon;
    private int currentWeaponIndex = 0;
    private int nextWeaponIndex;
    void Start()
    {
        InitWeapons();
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

    private void ChangeWeapon()
    {
        currentWeapon.gameObject.SetActive(false);
        currentWeaponIndex = weaponsListAfterInit.IndexOf(currentWeapon);
        nextWeaponIndex = (weaponsListAfterInit.Count == currentWeaponIndex + 1) ? 0 : (currentWeaponIndex + 1);
        currentWeapon = weaponsListAfterInit[nextWeaponIndex];
        currentWeapon.gameObject.SetActive(true);
    }
}
