using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public float cSpeed = 0.42f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;
        rb.velocity = new Vector2(cSpeed, 0) * delta;
    }
}
