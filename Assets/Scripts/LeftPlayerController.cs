using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerController : MonoBehaviour
{
    private float movementSpeed = .02f;

    // Start is called before the first frame update
    void Start()
    {
        // Starting position = (-8.0, 0.0, -2.4)
        Vector3 startingPosition = new Vector3 (-8.0f, 0.0f, -2.4f);

        // Set the player position to the starting position
        transform.position = startingPosition;

        //Vector3 rightPlayerPosition = GameObject.Find("RightPlayer").transform.position;
        //rightPlayerPosition = startingPosition;
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // move up on "w" key hold
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(0, movementSpeed, 0);
            Debug.Log("W Key hold");
        }
        // move down on "s" key hold
        if (Input.GetKey(KeyCode.S)) {
            transform.Translate(0, -movementSpeed, 0);
            Debug.Log("S Key hold");
        }
    }
}
