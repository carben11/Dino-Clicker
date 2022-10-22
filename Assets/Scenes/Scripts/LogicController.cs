using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    public float Clicks;
    public float CurrentLevel;
    public float ClicksTilNextLevel;
    public float Multiplier;
    public float LevelClicks;

    public EggController Egg;

    void Awake()
    {
        Clicks = 0f;
        CurrentLevel = 1f;  
        Multiplier = 1f;
        LevelClicks = 20f;
        ClicksTilNextLevel = 20f;
    }

    
    void Update()
    {
        if(ClicksTilNextLevel == 0f)
        {
            Egg.Hatch();
            CurrentLevel += 1;
            LevelClicks = Mathf.Pow(10f, CurrentLevel);
            ClicksTilNextLevel = LevelClicks;
        }
    }

    public void Click()
    {
        Clicks += Multiplier;
        ClicksTilNextLevel -= Multiplier;
    }
}
