using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject rightPlayer;
    private GameObject leftPlayer;

    // Movement speed of each player
    private float movementSpeed;

    private bool rightCanMoveUp = true;
    private bool rightCanMoveDown = true;
    private bool leftCanMoveUp = true;
    private bool leftCanMoveDown = true;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = 50f;

        rightPlayer = GameObject.Find("RightPlayer");
        leftPlayer = GameObject.Find("LeftPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        // Right player move up on arrow up hold
        if (rightCanMoveUp == true && Input.GetKey(KeyCode.UpArrow))
        {
            rightPlayer.transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }

        // Right player move down on arrow down hold
        if (rightCanMoveDown == true && Input.GetKey(KeyCode.DownArrow))
        {
            rightPlayer.transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }

        // Left player move up on "w" key hold
        if (leftCanMoveUp == true && Input.GetKey(KeyCode.W))
        {
            leftPlayer.transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }

        // Left player move down on "s" key hold
        if (leftCanMoveDown == true && Input.GetKey(KeyCode.S))
        {
            leftPlayer.transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }
    }

    // Sent when an incoming collider makes contact with this object's collider (2D physics only)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Name of the player
        string playerName = collision.otherCollider.name;
        // Name of the wall the player collides with
        string name = collision.gameObject.name;

        if (playerName == "RightPlayer")
        {
            if (name == "TopWall") rightCanMoveUp = false;
            else if (name == "BottomWall") rightCanMoveDown = false;
        }
        else if (playerName == "LeftPlayer")
        {
            if (name == "TopWall") leftCanMoveUp = false;
            else if (name == "BottomWall") leftCanMoveDown = false;
        }
    }

    // Sent when a collider on another object stops touching this object's collider (2D physics only)
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Name of the player that collides
        string playerName = collision.otherCollider.name;
        // Name of the object the players collides with
        string name = collision.gameObject.name;

        if (playerName == "RightPlayer")
        {
            if (name == "TopWall") rightCanMoveUp = true;
            else if (name == "BottomWall") rightCanMoveDown = true;
        }
        else if (playerName == "LeftPlayer")
        {
            if (name == "TopWall") leftCanMoveUp = true;
            else if (name == "BottomWall") leftCanMoveDown = true;
        }
    }
}
