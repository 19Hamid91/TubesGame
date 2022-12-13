using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
	{
	        // Kondisi ketika menyentuh tanah
            anim.SetTrigger("Boss_Idle");
	}

    private void OnCollisionEnter2D(Collision2D collision)
	{
		// if (Input.GetKeyDown(KeyCode.N))
		if (collision.collider.gameObject.CompareTag("Player"))
		{
            Debug.Log("Damage");
			anim.SetTrigger("Boss_Hurt");
		}

	}
}
