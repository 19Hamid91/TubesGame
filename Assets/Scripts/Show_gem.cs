using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_gem : MonoBehaviour
{
    void FixedUpdate()
    {
        GetComponent<Text>().text = Data.gem.ToString("0");
    }
}
