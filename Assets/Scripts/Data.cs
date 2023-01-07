using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public static int score;
    public static int gem;
    public static int min_gem_1 = 15;
    public static int min_gem_2 = 20;
    public static int lastScore = 0;
    public static int lastGem = 0;
    public static bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gem = 0;
        lastScore = 0;
        lastScore = 0;
        lastGem = 0;
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
