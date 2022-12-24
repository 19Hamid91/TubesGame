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

        Destroy (this.gameObject, 2f);
        this.enabled = false;

    }

    // Update is called once per frame
    // void Update()
    // {
        
    // }

    // private void OnCollisionStay2D(Collision2D collision)
	// {
	//         // Kondisi ketika menyentuh tanah
    //         // anim.SetTrigger("Boss_Idle");
	// }

    // private void OnCollisionEnter2D(Collision2D collision)
	// {
	// 	// if (Input.GetKeyDown(KeyCode.N))
	// 	// if (collision.collider.gameObject.CompareTag("Player"))
	// 	// {
    //     //     Debug.Log("Damage");
	// 	// 	anim.SetTrigger("Boss_Hurt");
	// 	// }

	// }
}
