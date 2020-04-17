using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ifYouWin : MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue = 1.0F;
    public float hSliderValue2 = 1.0F;
    public Text winText;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (winText.text == "You win! Game Created by Curtis Marcoux")
        {
            var main = ps.main;
            main.startSpeed = hSliderValue2;
            main.startSize = hSliderValue;
        }
    }
}
