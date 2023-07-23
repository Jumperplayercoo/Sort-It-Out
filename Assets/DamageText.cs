using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DamageText : MonoBehaviour
{
    public GameObject pellet;
    public TMP_Text damageText;
    void Update()
    {
        Bullet damage= pellet.GetComponent<Bullet>();
        int d = damage.damage ;
        damageText.text = "Damage: " + d.ToString();

    }
}
