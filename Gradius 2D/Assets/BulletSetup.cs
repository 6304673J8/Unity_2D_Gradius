using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetup : MonoBehaviour
{
    private Rigidbody2D rb;
    public float baseSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position += transform.right * baseSpeed * Time.deltaTime;
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Map")
        {
            speed = 0;
            hit = true;
            animator.SetTrigger(HitParamID);
        }
        if (collision.gameObject.tag == "Player")
        {
            speed = 0;
            hit = true;
            animator.SetTrigger(HitParamID);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            speed = 0;
            hit = true;
            animator.SetTrigger(HitParamID);
        }
    }*/
}
