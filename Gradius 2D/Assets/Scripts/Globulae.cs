using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globulae : MonoBehaviour
{
    public GameObject shipObject;

    public Transform player;
    public float moveSpeed = 1f;
    public float range;
    private Rigidbody2D enemyrb;
    private Vector2 movement;
    void Start()
    {
        shipObject = GameObject.FindGameObjectWithTag("Ship");
        enemyrb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Ship").transform.position, moveSpeed * Time.deltaTime);
        movement = transform.position;

        //Comprobar la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, GameObject.Find("Ship").transform.position);
        if (distanceToPlayer < range)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        enemyrb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Ship")
        {
            col.gameObject.GetComponent<ShipController>().hp -= 1;
            Destroy(gameObject);
            //Destroy(col.gameObject);
        }
    }
}
