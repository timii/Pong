using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Class for displaying points for the left player
public class LeftPointsCounter : MonoBehaviour
{
    private GameObject LeftPlayerPoints;
    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        LeftPlayerPoints = GameObject.Find("LeftPlayerPoints");

        LeftPlayerPoints.GetComponent<Text>().text = points.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current points from the BallController
        points = BallController.pointsLeft;

        LeftPlayerPoints.GetComponent<Text>().text = points.ToString();
    }
}
