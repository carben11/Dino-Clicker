using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    public ParticleSystem boom;
    public float Points;
    public float CurrentLevel;
    public float PointsTilNextLevel;
    public float Multiplier;
    public float LevelPoints;
    public float ACSpeed;
    public float ACTime;
    public float Clicks;
    public float level;
    public float rocks;
    public float levelRocks;
    public float multLevel;
    public float autoLevel;

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
        levelRocks = 10f;
        rocks = 0f;

        ACEnabled = false;
    }

    
    void Update()
    {
        if(PointsTilNextLevel <= 0f)
        {
            Egg.Hatch();
            CurrentLevel += 1;
            LevelPoints = Mathf.Pow(10f, CurrentLevel);
            rocks += levelRocks;
            PointsTilNextLevel = LevelPoints;
            level += 1f;
            levelRocks = LevelPoints / Mathf.Pow(CurrentLevel, 2);
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
        CreateBoom();
    }

    public void IncreaseMult()
    {
        if (rocks > Mathf.Pow(100, multLevel / 2))
        {
            Multiplier *= 2;
            rocks -= Mathf.Pow(100, multLevel / 2);
            multLevel += 1;
        }
        else
        {
            Debug.Log(Mathf.Pow(400, autoLevel / 2));
        }
    }

    public void EnableAuto()
    {
        if(rocks > Mathf.Pow(400, autoLevel / 2))
        {
            ACEnabled = true;
            ACTime *= 1.5f;
            rocks -= Mathf.Pow(400, autoLevel / 2);
            autoLevel += 1;
        }
        else
        {
            Debug.Log(Mathf.Pow(400, autoLevel / 2));
        }
    }

    private IEnumerator AutoClicker()
    {
        Points += 1;
        PointsTilNextLevel -= 1;
        Clicks += 1;
        yield return new WaitForSeconds(1 / ACTime);
        ACEnabled = true;
    }

    public void CreateBoom(){
        boom.Play();
    }

}
