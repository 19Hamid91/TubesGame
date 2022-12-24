using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public float cooldown;
	public float timer;
    // Update is called once per frame

    private void Start()
    {
        cooldown = 1;
		timer = cooldown;
    }
    void Update()
    {
        timer -= Time.deltaTime;
		if(timer < 0 ) 
        {
            if (Input.GetMouseButtonDown(0))
                {
                    Attack();
                    timer = cooldown;
                }
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if(enemy.GetComponent<BossController>().isInvulnerable)
            {
                return;
            }
            enemy.GetComponent<BossController>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
