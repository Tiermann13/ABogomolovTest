using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    private Weapons weapons;
    private Slider powerBar;
    private float maxPower = 100.0f;
    private float power;
    void Start()
    {
        weapons = GetComponentInParent<Weapons>();
        weapons.OnWeaponChanged += UpdatePowerBar;
        powerBar = GetComponent<Slider>();
    }

    private void UpdatePowerBar(WeaponBase currentWeapon)
    {
        power = currentWeapon.projectile.GetComponent<ProjectileBase>().damage;
        powerBar.value = power / maxPower;
    }
}
