using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 15.0f;
    public float xRange = 10;
    private float delay = 0;
    public Renderer rend;
    public Renderer rend2;
    public Renderer rend3;
    public Renderer rend4;
    public Renderer rend5;
    public Collider collide;
    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;
    public ParticleSystem explosion;
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();

        if (gameManager.gameOver == true)
        {
            Die();
        }
    
}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Plane"))
        {
            Die();
            gameManager.GameOver();
        }
        
    }

        private void Move()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (gameManager.gameOver == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
    }

    private void Fire()
    {
        if ((Input.GetKey(KeyCode.Mouse0)) && delay <= 0 && gameManager.gameOver == false)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            delay = .1f;
        }
        if ((Input.GetKey(KeyCode.Mouse1) && delay <= 0 && gameManager.gameOver == false))
        {
            Instantiate(projectilePrefab2, transform.position, projectilePrefab2.transform.rotation);
            delay = .5f;
        }
        delay -= Time.deltaTime;
    }

    private void Die()
    {
            rend.enabled = false;
            rend2.enabled = false;
            rend3.enabled = false;
            rend4.enabled = false;
            rend5.enabled = false;
            collide.enabled = false;
            explosion.Play();
        
    }

}
