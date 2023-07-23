using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PelletText : MonoBehaviour
{
    public GameObject cannon;
    public TMP_Text pelletText;
    void Update()
    {
        Shooting pellet = cannon.GetComponent<Shooting>();
        string color=pellet.color;
        if (color == "Blue")
        {
            pelletText.text = "Blue(Recycle)";
            pelletText.color = Color.blue;
        }
        if (color == "Green")
        {
            pelletText.text = "Green(Compost)";
            pelletText.color = Color.green;
        }
        if (color == "Red")
        {
            pelletText.text = "Red(Trash/Other)";
            pelletText.color = Color.red;
        }

    }
}
