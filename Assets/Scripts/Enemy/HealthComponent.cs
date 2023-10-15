using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   
[RequireComponent(typeof(SimpleFlash))]
public class HealthComponent : MonoBehaviour
{
    [SerializeField] protected SimpleFlash flashTrigger;
    //public Animator animator;

    private int maxHealth = 100;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        flashTrigger = GetComponent<SimpleFlash>();
    }
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        flashTrigger.Flash();
        Debug.Log("Hit");

        //animator.SetTrigger("Hurt");
        if (currentHealth == 0)
        {
            Die();
        }
    }
    void Die()
    {
        
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }



}
