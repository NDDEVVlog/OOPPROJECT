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

    public bool isAttacking = false;

    
    public KeyCode code;
    public AnimationClip attack;
    public static SingleAbility instance;
    public BaseSingleAbilitySkill[] baseSkill;

    public PlayerController controller;
    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        controller= GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (controller.RetriecveCustomInput(code) && !isAttacking)
        {
            //Attack();
            isAttacking = true;
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemyLayers);//create and detect enemy in range
       
        foreach (Collider2D enemy in hitEnemies)//hit points
        {
            enemy.GetComponent<HealthComponent>().TakeDamage(attackDamage,this.gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackLocation.position, attackRange);
    }
}
