using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speedV;
    public float speedH;
    public GameObject EnemyLaserPrefab;
    public float offsetBullet;
    public float fireRate;


    private GameObject bullet;

    private Rigidbody2D rigidBody;

    public float speed;

    private float TimeToShoot;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
    }

    private void Update()
    {
        float delta = Time.deltaTime * 1000;

        TimeToShoot += delta;

        if (TimeToShoot > fireRate)
        {
            Vector3 pos = -transform.right * offsetBullet + transform.position;
            bullet = Instantiate(EnemyLaserPrefab, pos, transform.rotation);
            Destroy(bullet, 1f);
            TimeToShoot = 0;
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("ToFollow").transform.position, speed * Time.fixedDeltaTime);

        MoveEnemy(transform.position);

    }
    void MoveEnemy(Vector2 direction)
    {
        rigidBody.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("ToFollow"))
        {
            Destroy(gameObject);
        }
    }
}
