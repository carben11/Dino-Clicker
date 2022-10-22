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
        slider.maxValue = 100;
        slider.value = 0;
        Debug.Log(slider.value);
    }

    private void Update()
    {
        slider.value = 100 / LC.ClicksTilNextLevel;
    }


}
