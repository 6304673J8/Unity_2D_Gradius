using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetup : MonoBehaviour
{
    public float baseSpeed;
    private void Update()
    {
        transform.position += transform.right * baseSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("EnemyLaser"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
        /*
            if (collision.gameObject.tag == "Enemy")
            {
                speed = 0;
                hit = true;
                animator.SetTrigger(HitParamID);
            }
        }*/
