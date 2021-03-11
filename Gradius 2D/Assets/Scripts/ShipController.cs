using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public enum Direction { NONE, UP, DOWN, LEFT, RIGHT };
    private Direction shipDirection = Direction.NONE;
    
    public float baseSpeed = 0.3f;
    public float currentSpeedH = 0.0f;
    public float currentSpeedV = 0.0f;

    private KeyCode upButton = KeyCode.W;
    private KeyCode downButton = KeyCode.S;
    private KeyCode leftButton = KeyCode.A;
    private KeyCode rightButton = KeyCode.D;

    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shipDirection = Direction.NONE;
        if (Input.GetKey(upButton))
        {
            shipDirection = Direction.UP;
        } else if (Input.GetKey(downButton))
        {
            shipDirection = Direction.DOWN;
        }

        if (Input.GetKey(leftButton))
        {
            shipDirection = Direction.LEFT;
        }
        else if (Input.GetKey(rightButton))
        {
            shipDirection = Direction.RIGHT;
        }
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;

        currentSpeedV = 0;
        currentSpeedH = 0;
        switch (shipDirection) {
            default: break;
            case Direction.UP:
                currentSpeedV = baseSpeed;
                break;
            case Direction.DOWN:
                currentSpeedV = -baseSpeed;
                break;
            case Direction.RIGHT:
                currentSpeedH = baseSpeed;
                break;
            case Direction.LEFT:
                currentSpeedH = -baseSpeed;
                break;
        }
        rigidBody.velocity = new Vector2(currentSpeedH, currentSpeedV) * delta;
    }
}
