using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGscroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSpeedZ;
    public Text winText;

    private Vector3 startPosition;
    private int score;

    void Start()
    {
        startPosition = transform.position;
        UpdateScore();
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSpeedZ);
        transform.position = startPosition + Vector3.forward * newPosition;
        UpdateScore();
    }


    void UpdateScore()
    {
        if (winText.text == "You win! Game Created by Curtis Marcoux")
        {
            float newPosition = Mathf.Repeat(Time.time * -5, tileSpeedZ);
            transform.position = startPosition + Vector3.forward * newPosition;
        }
    }
}
