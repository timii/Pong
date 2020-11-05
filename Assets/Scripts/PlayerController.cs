using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject rightPlayer;
    private GameObject leftPlayer;

    // Movement speed of each player
    private const float movementSpeed = 0.03f;

    private bool rightCanMoveUp = true;
    private bool rightCanMoveDown = true;
    private bool leftCanMoveUp = true;
    private bool leftCanMoveDown = true;

    // Start is called before the first frame update
    void Start()
    {
        rightPlayer = GameObject.Find("RightPlayer");
        leftPlayer = GameObject.Find("LeftPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        // Right player move up on arrow up hold
        if (rightCanMoveUp == true && Input.GetKey(KeyCode.UpArrow))
        {
            rightPlayer.transform.Translate(0, movementSpeed, 0);
        }

        // Right player move down on arrow down hold
        if (rightCanMoveDown == true && Input.GetKey(KeyCode.DownArrow))
        {
            rightPlayer.transform.Translate(0, -movementSpeed, 0);
        }

        // Left player move up on "w" key hold
        if (leftCanMoveUp == true && Input.GetKey(KeyCode.W))
        {
            leftPlayer.transform.Translate(0, movementSpeed, 0);
        }

        // Left player move down on "s" key hold
        if (leftCanMoveDown == true && Input.GetKey(KeyCode.S))
        {
            leftPlayer.transform.Translate(0, -movementSpeed, 0);
        }
    }

    // Function to make the player stop moving in the direction the wall is when touching a wall
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Name of the player that collides
        string playerName = collision.otherCollider.name;
        // Name of the object the players collides with
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

    // Function to make the players able to move up and down when not touching a wall
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
