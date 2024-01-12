using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicAudio;

public class VaseHealth : HealthComponent

{
    public Sprite another;
    bool die = false;
    GameObject DamageCauser;
    bool onceDie
    {
        get { return die; }
        set
        {
            if(die != true)
            {

                DynamicSound.PlaySound(GetComponent<ObjectInfo>());

            }
            die = value;
        }

    }
    public override void Die()
    {

        GetComponent<SpriteRenderer>().sprite = another;   
    }
    // Start is called before the first frame update
    public override void TakeDamage(float damage,GameObject DamageCauser)
    {
        this.DamageCauser = DamageCauser;
        onceDie = true;
        Die();
        
    }
}
