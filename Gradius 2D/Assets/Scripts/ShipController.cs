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

    private int lives = 3;

    //bullets
    //physics
    public GameObject bulletPrefab;

    public float bulletPosition;
    public float offsetBullet;
    //logic
    public float fireRate;
    public float cooldownFire = 0;
    private float secondsToNextFire = 1;
    private float nextFire;

    int maxBullets = 5;
    int bullets;

    //Ship
    private Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * fireRate;

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

        //Shoot logic
        if (cooldownFire == 0 && Input.GetKeyDown(KeyCode.Space))
        {
            ShootingLogic();
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > nextFire && fireRate > 0)
            {
                if (bullets > 0)
                {
                    nextFire = Time.time + fireRate * 2;
                    ShootingLogic();
                    bullets --;
                }
                if (bullets == 0)
                {
                    if (cooldownFire > Time.time)
                    {
                        cooldownFire = Time.time + secondsToNextFire;
                    }
                }
            }
        }
        if (Time.time > cooldownFire && bullets == 0)
        {   
            bullets = maxBullets;
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

    public void ShootingLogic()
    {
        Vector2 pos = transform.right * offsetBullet + transform.position;
        
        GameObject bullet = Instantiate(bulletPrefab, pos, transform.rotation);
        Destroy(bullet, 2);
    }
}
