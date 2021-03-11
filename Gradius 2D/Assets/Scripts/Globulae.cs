using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globulae : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 1f;
    public float range;
    private Rigidbody2D enemyrb;
    private Vector2 movement;

    void Start()
    {
        enemyrb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = player.position - transform.position ;
        //direction.Normalize();
        movement = direction;

        //Comprobar la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        /*if (distanceToPlayer < range)
        {
            Destroy(gameObject);
        }*/
    }

    private void FixedUpdate()
    {
        MoveEnemy(movement);
    }

    void MoveEnemy(Vector2 direction)
    {
        enemyrb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
