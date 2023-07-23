using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int defaultDamage = 50;
    public int damage=50;
    public string color;
    // Start is called before the first frame update
    void Start()
    {
        damage = defaultDamage;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyMovement enemy = hitInfo.GetComponent<EnemyMovement>();
        if (hitInfo.tag != "Player")
        {
            Destroy(gameObject);
        }
        if (enemy != null&&enemy.weakness==color)
        {
            enemy.TakeDamage(damage);
        }
    }

}
