using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightPointsCounter : MonoBehaviour
{
    private GameObject RightPlayerPoints;
    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        RightPlayerPoints = GameObject.Find("RightPlayerPoints");

        RightPlayerPoints.GetComponent<Text>().text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current points from the BallController
        points = BallController.pointsRight;

        RightPlayerPoints.GetComponent<Text>().text = points.ToString();
    }
}
