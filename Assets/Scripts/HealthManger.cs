using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManger : HealthComponent
{
    public Image healthBar;
    public float healthAmount = 100f;

    public override void TakeDamage(float damage,GameObject DamageCauser)
    {
        Debug.Log("TakeDamage");
        base.TakeDamage(damage, DamageCauser);
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
}
