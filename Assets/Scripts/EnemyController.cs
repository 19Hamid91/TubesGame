using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool isFlipped = false;
    public int maxHealth = 100;
    public int currentHealth;

    public float speed = 2.5f;
	public float attackRange = 3f;
	public int attackDamage = 10;

    public bool isInvulnerable = false;
    public float cooldown;
	public float timer;

    public Animator anim;
    public Transform player;

	Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
		rb = GetComponent<Rigidbody2D>();
		cooldown = 1;
		timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(!anim.GetBool("EnemyIsDead"))
		{
			if(player.GetComponent<PlayerController>().isInvulnerable)
			{
				return;
			}
			LookAtPlayer();
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
					anim.SetTrigger("Enemy_Attack");
					player.GetComponent<PlayerController>().TakeDamage(attackDamage);
					timer = cooldown;
				}
			}
		}
		return;
    }

    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Enemy_Hurt");

        if(currentHealth <= 0)
        {
            Die();
            Data.score += 50;
        }
    }

    void Die()
    {
        isInvulnerable = true;
        anim.SetBool("EnemyIsDead", true);
        Destroy (GetComponent<Rigidbody2D>());
        GetComponent<BoxCollider2D>().enabled = false ;
        this.enabled = false;

    }
}
