using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChild : MonoBehaviour
{
    public GameObject myObject;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Activator"))
        {
            myObject.SetActive(true);
        }
    }
}
