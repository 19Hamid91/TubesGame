using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public Animator anim;
    public Transform player;

	public bool isFlipped = false;
    public int maxHealth = 500;
    public int currentHealth;

    public HealthBar healthbar;

    public bool isInvulnerable = false;

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

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);
        anim.SetTrigger("Boss_Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isInvulnerable = true;
        Debug.Log("Enemy Die");
        anim.SetBool("isDead", true);
        Destroy (GetComponent<Rigidbody2D>());
        GetComponent<BoxCollider2D>().enabled = false ;
        this.enabled = false;

    }
}
