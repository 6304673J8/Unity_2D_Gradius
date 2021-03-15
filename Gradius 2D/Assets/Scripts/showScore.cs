using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class showScore : MonoBehaviour
{
 
    public Text scoreField;

    void Start()
    {
        scoreField = GetComponent<Text>();
    }

    void Update()
    {
        scoreField.text = "DOLOR: " + GameManager.Instance.score.ToString();
    }
}
