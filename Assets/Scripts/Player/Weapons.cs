using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] 
    private List<WeaponBase> weaponListPrefabs;
    private List<WeaponBase> weaponList = new List<WeaponBase>();
    
    private WeaponBase currentWeapon;
    private int currentWeaponIndex = 0;
    private int nextWeaponIndex;
    
    public delegate void WeaponChanged(WeaponBase currentWeapon);
    public event WeaponChanged OnWeaponChanged;
    
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
        if (weaponListPrefabs.Count == 0)
        {
            Debug.Log("EMPTY WEAPONLIST!!!");
            return;
        }
        
        foreach (WeaponBase weapon in weaponListPrefabs)
        {
            WeaponBase newWeapon = Instantiate(weapon, transform);
            weaponList.Add(newWeapon);
            newWeapon.gameObject.SetActive(false);
        }

        currentWeapon = weaponList[0];
        currentWeapon.gameObject.SetActive(true);
        OnWeaponChanged?.Invoke(currentWeapon);
    }
    
    private void ChangeWeapon()
    {
        currentWeapon.gameObject.SetActive(false);
        currentWeaponIndex = weaponList.IndexOf(currentWeapon);
        nextWeaponIndex = (weaponList.Count == currentWeaponIndex + 1) ? 0 : (currentWeaponIndex + 1);
        currentWeapon = weaponList[nextWeaponIndex];
        currentWeapon.gameObject.SetActive(true);
        
        OnWeaponChanged?.Invoke(currentWeapon);
    }
}
