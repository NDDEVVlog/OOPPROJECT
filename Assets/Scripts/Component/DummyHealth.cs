using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyHealth : HealthComponent
{
    public override void TakeDamage(float damage)
    {
        flashTrigger.Flash();
        Debug.Log("DummyHit");
    }
}
