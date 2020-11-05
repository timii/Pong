using UnityEngine;

public class BallController : MonoBehaviour
{
    private float currentSpeedX;
    private float currentSpeedY;
    private const float maxSpeedX = 0.04f;
    private const float minSpeedX = -maxSpeedX;
    private const float maxSpeedY = 0.04f;
    private const float minSpeedY = -maxSpeedY;
    private const float waitTime = 1.0f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        CreateRandomMovement();
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
                transform.Translate(currentSpeedX, currentSpeedY, 0);
            }
        }
    }

    // Function to handle collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.gameObject.name;

        if (name == "TopWall" || name == "BottomWall")
        {
            currentSpeedY *= -1;
        }

        else if (name == "Player")
        {
            BounceOffPlayer(collision);
        }

        // If the ball scores a point on the right side, add a point to the right player
        // and reset the ball position
        else if (name == "RightPointCounter")
        {
            PointsHandler.pointsLeft++;
            CreateRandomMovement();
            ResetBall();
        }

        // If the ball scores a point on the left side, add a point to the left player
        // and reset the ball position
        else if (name == "LeftPointCounter")
        {
            PointsHandler.pointsRight++;
            CreateRandomMovement();
            ResetBall();
        }
    }

    // Function to create random x and y speeds for the ball movement
    private void CreateRandomMovement() {
        float speedMargin = 0.01f; 

        currentSpeedX = Random.Range(minSpeedX, maxSpeedX);

        // Workaround to exclude values from -0.01 to 0.01
        if (currentSpeedX > -speedMargin && currentSpeedX < 0) currentSpeedX -= speedMargin;
        else if (currentSpeedX > 0 && currentSpeedX < speedMargin) currentSpeedX += speedMargin;

        currentSpeedY = Random.Range(minSpeedY, maxSpeedY);

        // Workaround to exclude values from -0.01 to 0.01
        if (currentSpeedY > -speedMargin && currentSpeedY < 0) currentSpeedY -= speedMargin;
        else if (currentSpeedY > 0 && currentSpeedY < speedMargin) currentSpeedY += speedMargin;
    }

    // Function to reset the ball position to the center
    private void ResetBall() {
        // Starting position = (0.0, 0.0, 0.0)
        Vector3 startingPosition = new Vector3 (0.0f, 0.0f, 0.0f);

        // Set the ball into the middle
        transform.position = startingPosition;

        // Remove the recorded 2 seconds
        timer = 0.0f;
    }

    // Function to bounce off a player according to which side it hit
    private void BounceOffPlayer(Collision2D coll) {
        Vector3 hit = coll.contacts[0].normal;
        
        // Get the angle at which the ball hit the player
        float angle = Vector3.Angle(hit, Vector3.up);

        // Hit top or bottom of players
        if (Mathf.Approximately(angle, 0) || Mathf.Approximately(angle, 180))
        {
            currentSpeedY *= -1;
        }

        // Hit right or left side of players   
        else if (Mathf.Approximately(angle, 90))
        {             
            currentSpeedX *= -1;

            // Add some randomness to the bounce off
            currentSpeedY += Random.Range(-0.01f, 0.01f);
            currentSpeedX += Random.Range(-0.01f, 0.01f);
        }
    }
}
