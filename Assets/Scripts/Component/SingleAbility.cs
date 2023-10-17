using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingleAbility : MonoBehaviour
{
    public Animator animator;
    public Transform attackLocation;
    public LayerMask enemyLayers;
    
    public float attackRange = 0.5f;
    public int attackDamage = 1;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    public KeyCode code;
    public AnimationClip attack;

    public BaseSingleAbilitySkill[] baseSkill;

    public PlayerController controller;

    public void Start()
    {
        controller= GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (controller.RetriecveCustomInput(code))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
                animator.Play(attack.name, GetComponent<SpriteRenderer>().sortingLayerID);
            }
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemyLayers);//create and detect enemy in range
        foreach (Collider2D enemy in hitEnemies)//hit points
        {
            enemy.GetComponent<HealthComponent>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
