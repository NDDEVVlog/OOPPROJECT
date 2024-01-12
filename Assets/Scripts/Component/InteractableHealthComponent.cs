using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class InteractableHealthComponent : HealthComponent
{
    public UnityEvent OnTakeDamage;

    public override void TakeDamage(float damage, GameObject damageCauser)
    {
        // Implement your code here

        // Notify observers about the damage
        OnTakeDamage.Invoke();
    }
}
