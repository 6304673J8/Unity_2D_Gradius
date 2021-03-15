using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public int hp;
    private int maxHp = 15;
    private Rigidbody2D bossrb;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        bossrb = this.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Victory();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            //Adds 1 to the num of times it hitd a wall
            hp--;
        }
    }

    public void Victory()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene("VictoryScene");
        }
    }
}
