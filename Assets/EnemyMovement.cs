using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject target;
    public float speed;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int damage;
    public string weakness;

    private GameObject spawner;

    private bool isAlive;

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

    private GameObject[] SpawnObjects;

    private Transform pos;

    void Start()
    {
        GameObject[] SO = { EnemyHalfEatenApple , EnemyBanana , EnemyPizza , EnemyBattery, EnemyGasolineTank , EnemyPlasticBottle , EnemySodaBottle, EnemySodaCan, EnemyWineBottle , EnemyPaper , EnemyPlasticBag , EnemyCardBoardBox };
        SpawnObjects = SO;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        target = GameObject.FindWithTag("Player");

        spawner = GameObject.FindWithTag("Spawner");

        isAlive = true;

        pos = GetComponent<Transform>();
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        FindObjectOfType<AudioManager>().Play("Hit");
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Turtle player = hitInfo.GetComponent<Turtle>();
        if (player != null && currentHealth > 0)
        {
            player.TakeDamage(damage);
            Die();
        }
    }

    public void Die()
    {
        if (gameObject.tag == "PlasticBag")
        {
            Instantiate(SpawnObjects[Random.Range(0, 10)], new Vector3(pos.position.x, pos.position.y, pos.position.z), Quaternion.identity);
            spawner.GetComponent<EnemySpawner>().enemiesLeft++;
        }
        if (gameObject.tag == "CardboardBox")
        {
            Instantiate(SpawnObjects[Random.Range(0, 11)], new Vector3(pos.position.x, pos.position.y, pos.position.z), Quaternion.identity);
            Instantiate(SpawnObjects[Random.Range(0, 11)], new Vector3(pos.position.x, pos.position.y, pos.position.z), Quaternion.identity);
            Instantiate(SpawnObjects[Random.Range(0, 11)], new Vector3(pos.position.x, pos.position.y, pos.position.z), Quaternion.identity);
            spawner.GetComponent<EnemySpawner>().enemiesLeft+=3;
        }
        if (isAlive)
        {
            isAlive = false; //enemy would "die" twice and break the counter so this fixes it;
            spawner.GetComponent<EnemySpawner>().enemiesLeft--;
            Destroy(gameObject);
        }
    }
}
