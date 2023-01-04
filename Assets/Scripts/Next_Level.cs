using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public Animator anim;
    public Transform target;
    public float range;
    public Text text;
    string scene;
    int minimum;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isOpen", false);
        text.enabled = false;
        scene = SceneManager.GetActiveScene().name;
        if(scene == "Level1")
        {
            minimum = Data.min_gem_1;
        }
        if(scene == "Level2")
        {
            minimum = Data.min_gem_2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance(transform.position, target.position) < range )
        {
            if(Data.gem >= minimum)
            {
                text.enabled = true;
                if (Input.GetKeyDown(KeyCode.N))
                {
                    NextLevel();
                }   
            }
        }
        else
        {
            // Debug.Log("Too far");
            text.enabled = false;
        }
    }
    
    void OnDrawGizmosSelected()
    {
        if (target == null)
            return;

        Gizmos.DrawWireSphere(target.position, range);
    }

    public void NextLevel()
    {
        anim.SetBool("isOpen", true);
        StartCoroutine(Next());
    }

    IEnumerator Next()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }  
}
