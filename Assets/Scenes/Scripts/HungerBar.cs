using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    private Slider slider;
    public LogicController LC;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = LC.LevelClicks;
        slider.value = 0f;
    }

    private void Update()
    {
        if (LC.ClicksTilNextLevel != 0f)
        {
            slider.value = LC.LevelClicks - LC.ClicksTilNextLevel;
        }
        slider.maxValue = LC.LevelClicks;
    }
}
