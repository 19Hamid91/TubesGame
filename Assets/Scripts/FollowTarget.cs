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
    float bg1_start;
    float bg2_start;
    float bg3_start;
    float camera_start;
    // bool yMax = false;

    // Start is called before the first frame update
    void Start()
    {
        string i = SceneManager.GetActiveScene().name;
        if(i == "Level1")
        {
            maxPosition = 320f;
        }
        else
        {
            maxPosition = 91f;
        }
        // yMax = false;

        bg1_start =  Bg1.transform.position.y;
        if(Bg2)
        {
            bg2_start =  Bg2.transform.position.y;
        }
        if(Bg3)
        {
            bg3_start =  Bg3.transform.position.y;
        }

        camera_start = transform.position.y;

        // player_start = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x != transform.position.x && player.position.x > -10 && player.position.x < maxPosition && player.position.y > 0.26f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, transform.position.z), 0.1f);
        }
        else if (player.position.x != transform.position.x && player.position.x > -10 && player.position.x < maxPosition && player.position.y <= 0.26f)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, camera_start, transform.position.z), 0.1f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, transform.position.y, transform.position.z), 0.1f);
        }

        //background
        if(Bg1)
        {
            Bg1.transform.position = new Vector2(transform.position.x * 1.0f, transform.position.y * 1.0f);
            if(Bg1.transform.position.y <= bg1_start)
            {
                Bg1.transform.position = new Vector2(transform.position.x * 1.0f, bg1_start);
            }
        }
        if(Bg2)
        {
            Bg2.transform.position = new Vector2(transform.position.x * 1.0f, transform.position.y * 1.0f);
            if(Bg2.transform.position.y <= bg2_start)
            {
                Bg2.transform.position = new Vector2(transform.position.x * 1.0f, bg2_start);
            }
        }
        if(Bg3)
        {
            Bg3.transform.position = new Vector2(transform.position.x * 1.0f, transform.position.y * 1.0f);
            if(Bg2.transform.position.y <= bg3_start)
            {
                Bg3.transform.position = new Vector2(transform.position.x * 1.0f, bg3_start);
            }
        }
    }
}
