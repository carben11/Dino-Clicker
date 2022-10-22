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
    public float ACSpeed;
    public float ACTime;

    public bool ACEnabled;

    public EggController Egg;

    void Awake()
    {
        Clicks = 0f;
        CurrentLevel = 1f;  
        Multiplier = 1f;
        LevelClicks = 20f;
        ClicksTilNextLevel = 20f;
        ACSpeed = 0f;
        ACTime = 1f;
        ACEnabled = false;
    }

    
    void Update()
    {
        if(ClicksTilNextLevel <= 0f)
        {
            Egg.Hatch();
            CurrentLevel += 1;
            LevelClicks = Mathf.Pow(10f, CurrentLevel);
            ClicksTilNextLevel = LevelClicks;
        }
        if(ACEnabled)
        {
            
        }
    }

    public void Click()
    {
        Clicks += Multiplier;
        ClicksTilNextLevel -= Multiplier;
    }

    public void IncreaseMult()
    {
        Multiplier *= 2;
        Debug.Log(Multiplier);
    }

    public void EnableAuto()
    {
        ACEnabled = true;
        ACSpeed += 1f;
    }

    private IEnumerator AutoClicker()
    {
        yield return new WaitForSeconds(1 / ACTime);
    }

}
