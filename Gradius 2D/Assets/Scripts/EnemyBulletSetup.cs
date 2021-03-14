using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSetup : MonoBehaviour
{
    public float speed;


    private bool hit = false;
    private float destroyTimer;
    private float animationDuration = 200f;
    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;

        float delta = Time.deltaTime * 1000;
        if (hit)
        {

            destroyTimer += delta;
            if (destroyTimer > animationDuration)
            {
                Destroy(gameObject);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ship"))
        {
            col.gameObject.GetComponent<ShipController>().hp -= 1;
            Destroy(gameObject);
        }
        if (col.CompareTag("Laser"))
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
    }
}
