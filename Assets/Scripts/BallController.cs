using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speedX;
    private float speedY;
    private const float minSpeed = -0.02f;
    private const float maxSpeed = 0.02f;
    public static int pointsRight;
    public static int pointsLeft;
    private const float waitTime = 1.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreateRandomMovement();

        ResetBall();

        //Wait();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitTime) {

            // Move the ball in a random direction
            transform.Translate(speedX, speedY, 0);
        }
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
            pointsLeft++;
            ResetTimer();
            Start();
        }

        // If the ball scores a point on the left side, add a point to the left player
        // and reset the ball position
        else if (collider.name == "LeftPointCounter") {
            pointsRight++;
            ResetTimer();
            Start();
        }
    }

    // Function to create random x and y speeds for the ball movement
    private void CreateRandomMovement() {
        float addSpeed = 0.01f; 

        speedX = Random.Range(minSpeed, maxSpeed);
        // Workaround to exclude values from -0.01 to 0.01
        if (speedX > -addSpeed && speedX < 0) speedX -= addSpeed;
        else if (speedX > 0 && speedX < addSpeed) speedX += addSpeed;

        speedY = Random.Range(minSpeed, maxSpeed);
        // Workaround to exclude values from -0.01 to 0.01
        if (speedY > -addSpeed && speedY < 0) speedY -= addSpeed;
        else if (speedY > 0 && speedY < addSpeed) speedY += addSpeed;
    }

    // Function to reset the ball position to the center
    private void ResetBall() {
        // Starting position = (0.0, 0.0, 0.0)
        Vector3 startingPosition = new Vector3 (0.0f, 0.0f, 0.0f);

        // Set the ball into the middle
        transform.position = startingPosition;
    }

    // Function to wait 1 second until the ball moves after being reset
    private void Wait() {
        System.DateTime currentTime = System.DateTime.Now;
        Debug.Log("currentTime: " + currentTime);
        System.DateTime goalTime = currentTime.AddSeconds(1);
        Debug.Log("goalTime: " + goalTime);

        // Stop the ball from moving 
        while (currentTime <= goalTime) {
            transform.Translate(0, 0, 0);
            currentTime = System.DateTime.Now;
            Debug.Log("currentTime in Loop" + currentTime);
        }
    }

    private void ResetTimer() {
        // Remove the recorded 2 seconds
        timer = 0.0f;
    }
}
