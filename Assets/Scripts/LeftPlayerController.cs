using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerController : MonoBehaviour
{
    private float movementSpeed = .02f;
    private bool canMoveUp = true;
    private bool canMoveDown = true;

    // Start is called before the first frame update
    void Start()
    {
        // Starting position = (-8.0, 0.0, 0.0)
        Vector3 startingPosition = new Vector3 (-8.0f, 0.0f, 0.0f);

        // Set the left player position to the starting position
        transform.position = startingPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // move up on "w" key hold
        if (canMoveUp == true && Input.GetKey(KeyCode.W)) {
            transform.Translate(0, movementSpeed, 0);
        }
        // move down on "s" key hold
        if (canMoveDown == true && Input.GetKey(KeyCode.S)) {
            transform.Translate(0, -movementSpeed, 0);
        }
    }

    // Function to handle collisions
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "TopWall") {
            canMoveUp = false;
        }
        else if (collider.name == "BottomWall") {
            canMoveDown = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collider) {
        if (collider.name == "TopWall") {
            canMoveUp = true;
        }
        else if (collider.name == "BottomWall") {
            canMoveDown = true;
        }
    }
}
