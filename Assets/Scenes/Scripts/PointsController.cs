using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsController : MonoBehaviour
{
    public LogicController lc;
    public TextMesh pointsPrinted;
    private float points;

    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        pointsPrinted = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        points = lc.Clicks;
        Debug.Log("Points Printer:" + pointsPrinted.text);

    }
}
