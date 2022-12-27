using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        // if (Data.gem >= 15)
        if (Input.GetKeyDown(KeyCode.N))
        {
            NextLevel();
        }    
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
