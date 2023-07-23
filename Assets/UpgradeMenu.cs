using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public static bool waveOver = false;
    public bool paused = false;
    public GameObject enemySpawner;

    public GameObject upgradeMenuUI;

    public GameObject player;
    public GameObject pelletBlue;
    public GameObject pelletGreen;
    public GameObject pelletRed;
    private Turtle stats;
    private Bullet b;
    private Bullet g;
    private Bullet r;
    private EnemySpawner spawner;

    void Update()
    {
        spawner = enemySpawner.GetComponent<EnemySpawner>();
        stats = player.GetComponent<Turtle>();
        if (spawner.nextWave && spawner.waveNumber != 11 &&stats.currentHealth!=0)
        {
            Pause();
            FindObjectOfType<AudioManager>().Play("PowerUp");
            spawner.nextWave = false;
        }
        b = pelletBlue.GetComponent<Bullet>();
        g = pelletGreen.GetComponent<Bullet>();
        r = pelletRed.GetComponent<Bullet>();
    }

    void Pause()
    {
        upgradeMenuUI.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    void Resume()
    {
        upgradeMenuUI.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }

    public void IncreaseHealth()
    {
        if (stats.currentHealth == stats.maxHealth)
        {
            ;
        }
        else if (stats.currentHealth + 20 > stats.maxHealth)
        {
            stats.currentHealth = stats.maxHealth;
            Resume();
            FindObjectOfType<AudioManager>().Play("Click");
        }
        else
        {
            stats.currentHealth += 20;
            Resume();
            FindObjectOfType<AudioManager>().Play("Click");
        }
    }

    public void IncreaseMaxHealth()
    {
        stats.maxHealth += 5;
        stats.currentHealth += 5;
        Resume();
        FindObjectOfType<AudioManager>().Play("Click");
    }

    public void IncreaseDamage()
    {
        b.damage += 10;
        g.damage += 10;
        r.damage += 10;
        Resume();
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
