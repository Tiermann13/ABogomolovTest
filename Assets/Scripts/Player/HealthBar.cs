using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Player player;
    private Slider healthBar;
    private float maxHealth;
    
    void Start()
    {
        player = GetComponentInParent<Player>();
        player.OnHealthChanged += UpdateHealthBar;
        maxHealth = player.maxHealth;
        healthBar = GetComponent<Slider>();
    }

    private void UpdateHealthBar(float health)
    {
        healthBar.value = health / maxHealth;
    }
}
