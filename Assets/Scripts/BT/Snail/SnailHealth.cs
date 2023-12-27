using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailHealth : HealthComponent
{
    public bool Hide= false;
    public override void TakeDamage(float damage, GameObject DamageCauser)
    {
        
        if(!Hide)
        base.TakeDamage(damage, DamageCauser);

        GetComponent<SnailBT>().OnTakeDamage();
    }

    public override void Die()
    { 
        base.Die();
        Destroy(this);

    }
}
