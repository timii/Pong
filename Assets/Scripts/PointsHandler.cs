using UnityEngine;
using UnityEngine.UI;

public class PointsHandler : MonoBehaviour
{
    private GameObject LeftPlayerPoints;
    private GameObject RightPlayerPoints;

    public static int pointsLeft;
    public static int pointsRight;

    // Start is called before the first frame update
    void Start()
    {
        pointsLeft = 0;
        pointsRight = 0;

        LeftPlayerPoints = GameObject.Find("LeftPlayerPoints");
        LeftPlayerPoints.GetComponent<Text>().text = pointsLeft.ToString();

        RightPlayerPoints = GameObject.Find("RightPlayerPoints");
        RightPlayerPoints.GetComponent<Text>().text = pointsRight.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        LeftPlayerPoints.GetComponent<Text>().text = pointsLeft.ToString();

        RightPlayerPoints.GetComponent<Text>().text = pointsRight.ToString();
    }
}
