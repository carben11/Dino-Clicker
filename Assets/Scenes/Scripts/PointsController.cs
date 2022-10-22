using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PointsController : MonoBehaviour
{
    public LogicController lc;
    public Text pointsText;
    private float points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points = lc.Points;
        float scaledPoints;
        string printPoints;
        if(points < 1000) {
            scaledPoints = points;
            printPoints = "POINTS: " + scaledPoints.ToString();
        }
        else {
            float temp = points/100;
            scaledPoints = (MathF.Floor(temp))/10;
            printPoints = "POINTS: " +  scaledPoints.ToString() + "K";
        }
        pointsText.text = printPoints;

    }
}
