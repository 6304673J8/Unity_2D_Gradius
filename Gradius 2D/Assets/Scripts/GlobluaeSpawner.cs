using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobluaeSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] Globulaes;
    public Vector3 pos;

    public float spawnTime = 3f;
    public float spawnDelay = 1f;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }
    void Spawn()
    {
        //Instantiate a random enemy.
        int enemyIndex = Random.Range(0, Globulaes.Length);
        Instantiate(Globulaes[enemyIndex], pos, transform.rotation);
    }
}
