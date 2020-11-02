using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speedX;
    private float speedY;
    private const float minSpeedX = -0.04f;
    private const float maxSpeedX = 0.04f;
    private const float minSpeedY = -0.04f;
    private const float maxSpeedY = 0.04f;
    public static int pointsRight;
    public static int pointsLeft;
    private const float waitTime = 1.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreateRandomMovement();

        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Wait for 1 second, then move the ball
        if (timer >= waitTime) {

            // Dont move ball when game is paused
            if (!(PauseMenuController.gameIsPaused))
            {
                // Move the ball in a random direction
                transform.Translate(speedX, speedY, 0);
            }
        }
    }

    // Function to handle collisions
    private void OnTriggerEnter2D(Collider2D collider) {
        // If the ball hits the top or bottom wall negate the y speed
        if (collider.name == "TopWall" || collider.name == "BottomWall") {
            speedY *= -1;
        }

        // If the ball hits the right or left wall or either of the players negate the x speed
        else if (collider.name == "RightPlayer" || collider.name == "LeftPlayer") {
            //speedX *= -1;
            BounceOffPlayer();
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

        speedX = Random.Range(minSpeedX, maxSpeedX);
        // Workaround to exclude values from -0.01 to 0.01
        if (speedX > -addSpeed && speedX < 0) speedX -= addSpeed;
        else if (speedX > 0 && speedX < addSpeed) speedX += addSpeed;

        speedY = Random.Range(minSpeedY, maxSpeedY);
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

    // Function to reset the timer variable after every point scored 
    private void ResetTimer() {
        // Remove the recorded 2 seconds
        timer = 0.0f;
    }

    // Function to calculate the bounce off angle when hitting a player
    private void BounceOffPlayer() {
        speedX *= -1;

        // Sprite size = 50x200 Pixels (Paddleheight = 200)
        //float relativeIntersectY = ();
    }

    // Function to reset the game
    public void ResetGame ()
    {
        pointsLeft = 0;
        pointsRight = 0;
        Start();
    }
}
