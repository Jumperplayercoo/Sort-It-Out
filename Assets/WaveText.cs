using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class WaveText : MonoBehaviour
{
    public GameObject spawner;
    public TMP_Text waveText;
    void Update()
    {
        EnemySpawner wave = spawner.GetComponent<EnemySpawner>();
        int w = wave.waveNumber;
        waveText.text = "Wave: " + w.ToString() + "/10";

    }
}
