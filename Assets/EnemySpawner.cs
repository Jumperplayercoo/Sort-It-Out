using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyHalfEatenApple;
    public GameObject EnemyBanana;
    public GameObject EnemyPizza;
    public GameObject EnemyBattery;
    public GameObject EnemyGasolineTank;
    public GameObject EnemyPlasticBag;
    public GameObject EnemyPlasticBottle;
    public GameObject EnemySodaBottle;
    public GameObject EnemySodaCan;
    public GameObject EnemyWineBottle;
    public GameObject EnemyPaper;
    public GameObject EnemyCardBoardBox;

    public GameObject gameWon;

    public int enemiesLeft;
    public bool nextWave;

    public int waveNumber;


    float[] bounds = new float[] { -8, 8, 5, 8, -8, 8, -8, -5, -6, -10, -5, 5, 10, 6, -5, 5 };


    void Start()
    {
        enemiesLeft = 0;
        waveNumber = 0;
        nextWave = false;

        gameWon = GameObject.FindWithTag("GameWon");
    }

    void Update()
    {
        if (enemiesLeft == 0 && waveNumber != 0)
        {
            nextWave = true;
        }
        if (enemiesLeft == 0)
        {
            waveNumber++;
            if (waveNumber == 1)
            {
                Spawn(2, EnemyPaper);
                enemiesLeft = 2;
            }
            if (waveNumber == 2)
            {
                Spawn(1, EnemyPaper);
                Spawn(1,EnemyHalfEatenApple);
                Spawn(1, EnemyGasolineTank);
                enemiesLeft = 3;
            }
            if (waveNumber == 3)
            {
                Spawn(1, EnemyPizza);
                Spawn(1, EnemyBanana);
                Spawn(1,EnemyWineBottle);
                Spawn(1,EnemySodaBottle);
                Spawn(1, EnemyPaper);
                enemiesLeft = 5;
            }
            if (waveNumber == 4)
            {
                Spawn(1, EnemyBattery);
                Spawn(2, EnemySodaCan);
                Spawn(3, EnemyPlasticBottle);
                enemiesLeft = 6;
            }
            if(waveNumber == 5)
            {
                Spawn(2,EnemyPlasticBag);
                enemiesLeft = 2;
            }
            if (waveNumber == 6)
            {
                Spawn(1, EnemyPlasticBag);
                Spawn(2, EnemyHalfEatenApple);
                Spawn(2,EnemyBattery);
                Spawn(1, EnemyWineBottle);
                Spawn(1, EnemyPizza);
                enemiesLeft = 7;
            }
            if (waveNumber == 7)
            {
                Spawn(2, EnemyPlasticBag);
                Spawn(2, EnemyGasolineTank);
                Spawn(2, EnemyBanana);
                Spawn(1, EnemySodaCan);
                Spawn(1, EnemySodaBottle);
                enemiesLeft = 8;
            }
            if (waveNumber == 8)
            {
                Spawn(1, EnemyCardBoardBox);
                enemiesLeft = 1;
            }
            if (waveNumber == 9)
            {
                Spawn(1, EnemyCardBoardBox);
                Spawn(3, EnemyPlasticBag);
                Spawn(3, EnemyBattery);
                enemiesLeft = 7;
            }
            if(waveNumber == 10)
            {
                Spawn(3, EnemyCardBoardBox);
                enemiesLeft = 3;
            }
            if (waveNumber == 11)
            {
                FindObjectOfType<AudioManager>().Play("Win");
                gameWon.GetComponent<GameWonMenu>().Pause();
                enemiesLeft = 1;
            }
        }
    }

    void Spawn(int number, GameObject enemy)
    {
        for (int i = 0; i < number; i++)
        {
            int j = Random.Range(1, 5);
            Vector3 pos = new Vector3(Random.Range(bounds[j * 4 - 4], bounds[j * 4 - 3]), Random.Range(bounds[j * 4 - 2], bounds[j * 4 - 1]), 0);
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }
}
