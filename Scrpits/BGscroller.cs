using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGscroller : MonoBehaviour
{

    public float scrollSpeed;
    public float tileSpeedZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSpeedZ);
        transform.position = startPosition + Vector3.forward * newPosition;
    }
}
