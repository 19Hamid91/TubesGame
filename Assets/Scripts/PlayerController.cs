using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    	bool isJump = true;
	    public bool isDead = false;
	    int idMove = 0;
	    Animator anim;

		public float cooldown;
		public float timer;

		public int maxHealth = 100;
    	public int currentHealth;
		public bool isInvulnerable = false;
		public HealthBar healthbar;

		public AudioClip soundEffect;
		private AudioSource sound;
	    
	    // Use this for initialization
	    private void Start()
	    {
	        anim = GetComponent<Animator>();
			cooldown = 1;
			timer = cooldown;

			currentHealth = maxHealth;
        	healthbar.SetMaxHealth(maxHealth);

			sound = gameObject.AddComponent<AudioSource>();
        	sound.clip = soundEffect;
	    }
	    
	    // Update is called once per frame
	    void Update()
	    {
	        if (Input.GetKeyDown(KeyCode.A))
	        {
	            MoveLeft();
	        }
	        if (Input.GetKeyDown(KeyCode.D))
	        {
	            MoveRight();
	        }
	        if (Input.GetKeyDown(KeyCode.Space))
	        {
	            Jump();
	        }
	        if (Input.GetKeyUp(KeyCode.D))
	        {
	            Idle();
	        }
	        if (Input.GetKeyUp(KeyCode.A))
	        {
	            Idle();
	        }
	        Move();
			if(currentHealth <= 0)
			{
				Die();
			}
	    }
	    
	    private void OnCollisionStay2D(Collision2D collision)
	    {
	        // Kondisi ketika menyentuh tanah
	        if (isJump)
	        {
	            anim.ResetTrigger("Jump");
	            if (idMove == 0) anim.SetTrigger("Idle");
	            isJump = false;
	        }
	 
	    }
	    
	    private void OnCollisionExit2D(Collision2D collision)
	    {
	        // Kondisi ketika menyentuh tanah
	        anim.SetTrigger("Jump");
	        anim.ResetTrigger("Run");
	        anim.ResetTrigger("Idle");
	        anim.ResetTrigger("Hurt");
	        isJump = true;
	    }

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.transform.tag.Equals("Traps"))
			{
				currentHealth -= 5;
				healthbar.setHealth(currentHealth);
				anim.SetTrigger("Hurt");
			}
			if (collision.transform.tag.Equals("Gem"))
			{
				sound.Play();
				Destroy(collision.gameObject);
				Data.score += 10;
				Data.gem += 1;
			}
			if (collision.transform.tag.Equals("Fall"))
			{
				Die();
			}
		}
 
	    public void MoveRight()
	    {
	        idMove = 1;
	    }
	    
	    public void MoveLeft()
	    {
	        idMove = 2;
	    }
	    
	    private void Move()
	    {
	        if (idMove == 1 && !isDead)
	        {
	            // Kondisi ketika bergerak ke kekanan
	            if (!isJump) anim.SetTrigger("Run");
	            transform.Translate(1 * Time.deltaTime * 5f, 0, 0);
	            transform.localScale = new Vector3(5f, 5f, 1f);
	        }
	        if (idMove == 2 && !isDead)
	        {
	            // Kondisi ketika bergerak ke kiri
	            if (!isJump) anim.SetTrigger("Run");
	            transform.Translate(-1 * Time.deltaTime * 5f, 0, 0);
	            transform.localScale = new Vector3(-5f, 5f, 1f);
	        }
	    }
	    
	    public void Jump()
	    {
	        if (!isJump)
	        {
	            // Kondisi ketika Loncat           
	            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 400f);
	        }
	    }
	    
	    
	    public void Idle()
	    {
	        // kondisi ketika idle/diam
	        if (!isJump)
	        {
	            anim.ResetTrigger("Jump");
	            anim.ResetTrigger("Run");
	            anim.SetTrigger("Idle");
	        }
	        idMove = 0;
	    }

		public void TakeDamage(int damage)
		{
			currentHealth -= damage;
			healthbar.setHealth(currentHealth);
			anim.SetTrigger("Hurt");
		}

		void Die()
		{
			isInvulnerable = true;
			anim.SetBool("isDead", true);
			Destroy (GetComponent<Rigidbody2D>());
        	GetComponent<BoxCollider2D>().offset = new Vector2(0, -5);
			GetComponent<Player_attack>().enabled = false;
			this.enabled = false;
			Debug.Log("Player Die");
		}
}
