using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowTarget : MonoBehaviour
{

    public Transform player;
    public Transform Bg1;
	public Transform Bg2;
    public Transform Bg3;
    public float maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        if(y == 0)
        {
            maxPosition = 311f;
        }
        else
        {
            maxPosition = 81.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x != transform.position.x && player.position.x > 0 && player.position.x < maxPosition)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), 0.1f);
        }
        if(Bg1)
        {
            Bg1.transform.position = new Vector2(transform.position.x * 1.0f, Bg1.transform.position.y);
        }
        if(Bg2)
        {
            Bg2.transform.position = new Vector2(transform.position.x * 1.0f, Bg2.transform.position.y);
        }
        if(Bg3)
        {
            Bg3.transform.position = new Vector2(transform.position.x * 1.0f, Bg3.transform.position.y);
        }
    }
}
