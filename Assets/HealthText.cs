using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HealthText : MonoBehaviour
{
    public GameObject player;
    public TMP_Text healthText;
    // Update is called once per frame
    void Update()
    {
        Turtle health = player.GetComponent<Turtle>();
        int h = health.currentHealth;
        int maxh = health.maxHealth;
        healthText.text = "Health: " + h.ToString() + "/" + maxh.ToString();
        if (h <= 30)
        {
            healthText.color = Color.red;
        }
    }
}
