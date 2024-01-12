using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
[RequireComponent(typeof(SimpleFlash))]
public class HealthComponent : MonoBehaviour
{
    [SerializeField] protected SimpleFlash flashTrigger;
    //public Animator animator;

    public float maxHealth = 100;
    public float currentHealth;
    protected string Name;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        flashTrigger = GetComponent<SimpleFlash>();
    }
    public virtual void TakeDamage(float damage, GameObject DamageCauser)
    {
        currentHealth -= damage;
        flashTrigger.Flash();


        //animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }



}


