using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    public int Clicks;
    public int CurrentLevel;
    public int ClicksTilNextLevel;
    public int Multiplier;
    public int LevelClicks;

    public EggController Egg;

    void Start()
    {
        Clicks = 0;
        CurrentLevel = 1;  
        Multiplier = 1;
        LevelClicks = 10;
        ClicksTilNextLevel = 10;
    }

    
    void Update()
    {
        if(ClicksTilNextLevel <= 0)
        {
            Egg.Hatch();
            CurrentLevel += 1;
            LevelClicks = 10 ^ CurrentLevel;
            ClicksTilNextLevel = LevelClicks;
        }
    }

    public void Click()
    {
        Clicks += Multiplier;
        ClicksTilNextLevel -= Multiplier;
        Debug.Log(ClicksTilNextLevel);
    }
}
