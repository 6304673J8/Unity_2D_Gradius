using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobluaeSpawner : MonoBehaviour
{
    [SerializeField]
    private Globulae globulaePrefab;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Globulae newGlobulae = Instantiate(globulaePrefab);
            newGlobulae.transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        }    
    }
}
