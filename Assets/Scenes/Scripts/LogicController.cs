using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    public float Points;
    public float CurrentLevel;
    public float PointsTilNextLevel;
    public float Multiplier;
    public float LevelPoints;
    public float ACSpeed;
    public float ACTime;
    public float Clicks;
    public float level;

    public bool ACEnabled;

    public EggController Egg;


    void Awake()
    {
        Points = 0f;
        CurrentLevel = 1f;  
        Multiplier = 1f;
        LevelPoints = 20f;
        PointsTilNextLevel = 20f;
        ACSpeed = 0f;
        ACTime = 1f;
        level = 0f;
        ACEnabled = false;
    }

    
    void Update()
    {
        if(PointsTilNextLevel <= 0f)
        {
            Egg.Hatch();
            CurrentLevel += 1;
            LevelPoints = Mathf.Pow(10f, CurrentLevel);
            PointsTilNextLevel = LevelPoints;
            level += 1f;
        }
        if(ACEnabled == true)
        {
            StartCoroutine(AutoClicker());
            ACEnabled = false;
        }
    }

    public void Click()
    {
        Points += Multiplier;
        PointsTilNextLevel -= Multiplier;
        Clicks += 1;
    }

    public void IncreaseMult()
    {
        Multiplier *= 2;
        Debug.Log(Multiplier);
    }

    public void EnableAuto()
    {
        ACEnabled = true;
        ACTime *= 1.5f;
    }

    private IEnumerator AutoClicker()
    {
        Points += 1;
        PointsTilNextLevel -= 1;
        Clicks += 1;
        Debug.Log(ACTime);
        yield return new WaitForSeconds(1 / ACTime);
        ACEnabled = true;
    }

}
