using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float speed;
    Vector2 movement;
    private Rigidbody2D rb;

    public Animator animator;

    private bool isFacingRight = false;

    public HealthBar healthBar;

    public GameObject gameOver;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        gameOver= GameObject.FindWithTag("GameOver");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        healthBar.SetHealth(currentHealth);
        Flip();
        animator.SetFloat("Speed", movement.sqrMagnitude);

        Vector3 pos = healthBar.transform.position;
        pos.x = transform.position.x;
        pos.y = transform.position.y - 0.3f;
        healthBar.transform.position = pos;
    }

    private void Flip()
    {
        if(isFacingRight&&movement.x<0f||!isFacingRight && movement.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        FindObjectOfType<AudioManager>().Play("Hit");
        if (currentHealth <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            currentHealth = 0;
            gameOver.GetComponent<GameOverMenu>().Pause();
        }
    }
}
