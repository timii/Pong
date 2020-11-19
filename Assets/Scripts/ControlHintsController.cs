using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHintsController : MonoBehaviour
{
    // Array of all the sprites needed
    public Sprite[] sprites;

    // All the game objects needed
    Sprite ArrowUpKey;
    Sprite ArrowDownKey;
    Sprite WKey;
    Sprite SKey;

    // Start is called before the first frame update
    void Start()
    {
        ArrowUpKey = GameObject.Find("ArrowUp").GetComponent<SpriteRenderer>().sprite;
        ArrowDownKey = GameObject.Find("ArrowDown").GetComponent<SpriteRenderer>().sprite;
        WKey = GameObject.Find("WKey").GetComponent<SpriteRenderer>().sprite;
        SKey = GameObject.Find("SKey").GetComponent<SpriteRenderer>().sprite;

        // Set the standard sprites
        ArrowUpKey = sprites[0];
        ArrowDownKey = sprites[0];
        SKey = sprites[2];
        WKey = sprites[4];
    }

    // Update is called once per frame
    void Update()
    {
        // If arrow up key pressed change the sprite
        if (Input.GetKey(KeyCode.UpArrow)) ArrowUpKey = sprites[1];
        else ArrowUpKey = sprites[0];

        // If arrow down key pressed change the sprite
        if (Input.GetKey(KeyCode.DownArrow)) ArrowDownKey = sprites[1];
        else ArrowDownKey = sprites[0];

        // If s key pressed change the sprite
        if (Input.GetKey(KeyCode.S)) SKey = sprites[3];
        else SKey = sprites[2];

        // If w key pressed change the sprite
        if (Input.GetKey(KeyCode.W)) WKey = sprites[5];
        else WKey = sprites[4];
    }
}
