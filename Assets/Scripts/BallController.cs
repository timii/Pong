using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 50;
    private const float waitTime = 1.0f;

    private int maxPoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Don't move the ball
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Start moving the ball after 1 second
        Invoke("MoveBall", waitTime);
    }

    // Function to move the ball by giving it an initial force
    void MoveBall()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

    // Sent when an incoming collider makes contact with this object's collider (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string name = collision.gameObject.name;

        if (name == "Player")
        {
            BounceOffPlayer(collision);

            // Play bounce off sound
            FindObjectOfType<AudioManager>().Play("BallBounce");
        }

        // If the ball scores a point on the right side, add a point to the right player
        else if (name == "RightPointCounter")
        {
            PointsHandler.pointsLeft++;
            // End game at max points points
            if (PointsHandler.pointsLeft == maxPoints) FindObjectOfType<WinnerScreenController>().EndGame("Left Player");

            ResetBall();
        }

        // If the ball scores a point on the left side, add a point to the left player
        else if (name == "LeftPointCounter")
        {
            PointsHandler.pointsRight++;
            // End game at max points points
            if (PointsHandler.pointsRight == maxPoints) FindObjectOfType<WinnerScreenController>().EndGame("Right Player");

            ResetBall();
        }
    }

    // Function to reset the ball position to the center
    private void ResetBall() {
        // Starting position = (0.0, 0.0, 0.0)
        Vector3 startingPosition = new Vector3 (0.0f, 0.0f, 0.0f);

        // Set the ball into the middle
        transform.position = startingPosition;

        Start();
    }

    /// <summary>
    /// Function to bounce off a player according to which side it hit
    /// </summary>
    /// <param name="col">the collision2d data associated with the collision</param>
    private void BounceOffPlayer(Collision2D col)
    {
        // source: https://noobtuts.com/unity/2d-pong-game

        // Helping variable to find out which player the ball hit
        float xPos = gameObject.transform.position.x;

        // Hit the left Player?
        if (xPos < 0)
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.gameObject.transform.Find("LeftPlayer").position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        // Hit the right Player?
        if (xPos > 0)
        {
            // Calculate hit Factor
            float y = hitFactor(transform.position,
                                col.gameObject.transform.Find("RightPlayer").position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }
        
    /// <summary>
    /// Function to calculate the angle of the ball bounce
    /// </summary>
    /// <param name="ballPos">y coordinate of the ball</param>
    /// <param name="playerPos">y coordinate of the player it hit</param>
    /// <param name="playerHeight">height of the player</param>
    /// <returns>the relative position of the ball to the player</returns>
    float hitFactor(Vector2 ballPos, Vector2 playerPos, float playerHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the player
        // ||
        // ||  0 <- at the middle of the player
        // ||
        // || -1 <- at the bottom of the player
        return (ballPos.y - playerPos.y) / playerHeight;
    }
}
