using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Walk : StateMachineBehaviour
{
     public float speed = 1.5f;
	public float attackRange = 2f;
	public int attackDamage = 10;

	public float cooldown;
	public float timer;

	Transform player;
	Rigidbody2D rb;
	EnemyController enemy;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		rb = animator.GetComponent<Rigidbody2D>();
		enemy = animator.GetComponent<EnemyController>();
		cooldown = 1;
		timer = cooldown;

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if(!animator.GetBool("EnemyIsDead"))
		{
			if(player.GetComponent<PlayerController>().isInvulnerable)
			{
				return;
			}
			enemy.LookAtPlayer();

			Vector2 target = new Vector2(player.position.x, rb.position.y);
			Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
			rb.MovePosition(newPos);

			if (Vector2.Distance(player.position, rb.position) <= attackRange)
			{
				if(player.GetComponent<PlayerController>().isInvulnerable)
				{
					return;
				}
				timer -= Time.deltaTime;
				if(timer < 0 ) 
				{
					animator.SetTrigger("Enemy_Attack");
					player.GetComponent<PlayerController>().TakeDamage(attackDamage);
					timer = cooldown;
				}
			}
		}
		return;
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.ResetTrigger("Enemy_Attack");
	}
}
