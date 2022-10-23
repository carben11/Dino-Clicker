using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public float rocks;
    public float levelRocks;
    public float multLevel;
    public float autoLevel;

    public bool ACEnabled;

    public EggController Egg;
    public Button clickerUpgrade;
    public Button autoUpgrade;
    public Text warning;
    public ParticleSystem levelUp;


    void Awake()
    {
        warning.GetComponent<RectTransform>().localScale = new Vector3(0f, 0f, 0f);
        Points = 0f;
        CurrentLevel = 1f;  
        Multiplier = 1f;
        LevelPoints = 10f;
        PointsTilNextLevel = 10f;
        ACSpeed = 0f;
        ACTime = 1f;
        level = 1f;
        rocks = 0f;
        levelRocks = 2f;
        autoLevel = 1f;
        multLevel = 1f;
        levelUp.Pause();

        ACEnabled = false;
    }

    
    void Update()
    {
        if(PointsTilNextLevel <= 0f)
        {
            Egg.Hatch();
            CurrentLevel += 1;
            LevelPoints = Mathf.Pow(5f, CurrentLevel);
            PointsTilNextLevel = LevelPoints;
            level += 1f;
            rocks += levelRocks;
            levelRocks = LevelPoints / 5;
            levelUp.Play();

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
        if(rocks >= Mathf.Pow(100f, multLevel))
        {
            Multiplier *= 2;
            rocks -= Mathf.Pow(100f, multLevel);
            multLevel += 1;
        }
        else
        {
            StartCoroutine(RedFlash(clickerUpgrade));
        }
    }

    public void EnableAuto()
    {
        if (rocks >= Mathf.Pow(400f, autoLevel))
        {
            ACEnabled = true;
            ACTime *= 1.5f;
            rocks -= Mathf.Pow(400f, autoLevel);
        }
        else
        {
            StartCoroutine(RedFlash(autoUpgrade));
        }
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
    private IEnumerator RedFlash(Button button)
    {
        warning.GetComponent<RectTransform>().localScale = new Vector3(.005f, .005f, 0f);
        button.GetComponent<Image>().color = Color.red;
        yield return new WaitForSeconds(.25f);
        button.GetComponent<Image>().color = Color.white;
        yield return new WaitForSeconds(1f);
        warning.GetComponent<RectTransform>().localScale = new Vector3(0f,0f,0f);
    }
}
