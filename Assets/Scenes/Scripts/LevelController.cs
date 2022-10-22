using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelController : MonoBehaviour
{
    public LogicController lc;
    public Text levelsText;
    private float levelt;
    // Start is called before the first frame update
    void Start()
    {
        levelt = 1;
    }

    // Update is called once per frame
    void Update()
    {
        levelt = lc.level;
        levelsText.text = "LEVEL: " + levelt.ToString();

        
    }
}
