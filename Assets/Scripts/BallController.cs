using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speedX;
    private float speedY;
    private int pointsRight;
    private int pointsLeft;

    // Start is called before the first frame update
    void Start()
    {
        // Starting position = (0.0, 0.0, 0.0)
        Vector3 startingPosition = new Vector3 (0.0f, 0.0f, 0.0f);

        // Give the ball a random velocity and direction
        speedX = Random.Range(-0.03f, 0.03f);
        speedY = Random.Range(-0.03f, 0.03f);

        // Set the ball into the middle
        transform.position = startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speedX, speedY, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        // If the ball hits the top or bottom wall negate the y speed
        if (collider.name == "TopWall" || collider.name == "BottomWall") {
            speedY *= -1;
        }

        // If the ball hits the right or left wall or either of the players negate the x speed
        else if (collider.name == "RightPlayer" || collider.name == "LeftPlayer") {
            speedX *= -1;
        }

        // If the ball scores a point on the right side, add a point to the right player
        // and reset the ball position
        else if (collider.name == "RightPointCounter") {
            pointsRight++;
            Start();
            Debug.Log("Points: " + pointsLeft + ":" + pointsRight);
        }

        // If the ball scores a point on the left side, add a point to the left player
        // and reset the ball position
        else if (collider.name == "LeftPointCounter") {
            pointsLeft++;
            Start();
            Debug.Log("Points: " + pointsLeft + ":" + pointsRight);
        }
    }
}
