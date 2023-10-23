using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseHealth : HealthComponent

{
    public Sprite another;
    public override void Die()
    {
        GetComponent<SpriteRenderer>().sprite = another;   
    }
    // Start is called before the first frame update
    public override void TakeDamage(float damage)
    {
       
            Die();
        
    }
}
