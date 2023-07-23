using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject pelletBlue;
    public GameObject pelletRed;
    public GameObject pelletGreen;
    public string color="Blue";

    public float pelletForce = 20f;


    public Rigidbody2D rb;
    public Camera cam;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        Bullet b = pelletBlue.GetComponent<Bullet>();
        Bullet g = pelletGreen.GetComponent<Bullet>();
        Bullet r = pelletRed.GetComponent<Bullet>();
        b.damage = 50;
        g.damage = 50;
        r.damage = 50;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1f;
        }
        if (Time.timeScale == 0)
        {
            return;
        }
        if (Input.GetKeyDown("1"))
        {
            color = "Blue";
        }
        if (Input.GetKeyDown("2"))
        {
            color = "Green";
        }
        if (Input.GetKeyDown("3"))
        {
            color = "Red";
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg-90f;
        rb.rotation = angle;
    }

    void Shoot()
    {
        if (color == "Blue")
        {
            GameObject pellet = Instantiate(pelletBlue, firePoint.position, firePoint.rotation);
            Rigidbody2D pel = pellet.GetComponent<Rigidbody2D>();
            pel.AddForce(firePoint.up * pelletForce, ForceMode2D.Impulse);
        }
        else if (color == "Green")
        {
            GameObject pellet = Instantiate(pelletGreen, firePoint.position, firePoint.rotation);
            Rigidbody2D pel = pellet.GetComponent<Rigidbody2D>();
            pel.AddForce(firePoint.up * pelletForce, ForceMode2D.Impulse);
        }
        else if (color == "Red")
        {
            GameObject pellet = Instantiate(pelletRed, firePoint.position, firePoint.rotation);
            Rigidbody2D pel = pellet.GetComponent<Rigidbody2D>();
            pel.AddForce(firePoint.up * pelletForce, ForceMode2D.Impulse);
        }
    }
}
