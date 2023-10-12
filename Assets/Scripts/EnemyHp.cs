using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    //public Animator animator;

    private int maxHealth = 100;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //animator.SetTrigger("Hurt");
        if(currentHealth == 0)
        {
            Die();
        }
    }
    void Die()
    {
        Debug.Log("Dummy die");
        //animator.SetBool("isDeath", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
