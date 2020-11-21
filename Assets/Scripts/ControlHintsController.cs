using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHintsController : MonoBehaviour
{
    // Array of all the sprites needed
    public Sprite[] sprites;

    // All the game objects needed
    SpriteRenderer ArrowUpKey;
    SpriteRenderer ArrowDownKey;
    SpriteRenderer SKey;
    SpriteRenderer WKey;

    // Start is called before the first frame update
    void Start()
    {
        ArrowUpKey = GameObject.Find("ArrowUp").GetComponent<SpriteRenderer>();
        ArrowDownKey = GameObject.Find("ArrowDown").GetComponent<SpriteRenderer>();
        SKey = GameObject.Find("SKey").GetComponent<SpriteRenderer>();
        WKey = GameObject.Find("WKey").GetComponent<SpriteRenderer>();

        // Set the standard sprites
        ArrowUpKey.sprite = sprites[0];
        ArrowDownKey.sprite = sprites[0];
        SKey.sprite = sprites[2];
        WKey.sprite = sprites[4];
    }

    // Update is called once per frame
    void Update()
    {
        // If arrow up key pressed change the sprite
        if (Input.GetKey(KeyCode.UpArrow)) ArrowUpKey.sprite = sprites[1];
        else ArrowUpKey.sprite = sprites[0];

        // If arrow down key pressed change the sprite
        if (Input.GetKey(KeyCode.DownArrow)) ArrowDownKey.sprite = sprites[1];
        else ArrowDownKey.sprite = sprites[0];

        // If s key pressed change the sprite
        if (Input.GetKey(KeyCode.S)) SKey.sprite = sprites[3];
        else SKey.sprite = sprites[2];

        // If w key pressed change the sprite
        if (Input.GetKey(KeyCode.W)) WKey.sprite = sprites[5];
        else WKey.sprite = sprites[4];
    }
}
