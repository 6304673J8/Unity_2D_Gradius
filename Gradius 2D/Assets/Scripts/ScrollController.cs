using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public float cSpeed = 0.42f;
    private float currentSpeed;
    private Rigidbody2D cameraRb;
    public int bossStage;

    //private EnemyAI toBattle;

    // Start is called before the first frame update
    void Start()
    {
        
        currentSpeed = cSpeed;
        cameraRb = GetComponent<Rigidbody2D>();
        //toBattle = GetComponent<EnemyAI>();
        //toBattle.enabled = false;
    }
    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;
        if (transform.position.x >= bossStage)
        {
            currentSpeed = 0;
        }
        cameraRb.velocity = new Vector2(currentSpeed, 0) * delta;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }

    }
}
