using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    
    [HideInInspector] public int hp;
    [HideInInspector] public int speed;
    public Renderer rend;
    public Renderer rend1;
    public Renderer rend2;
    public Collider collide;
    public ParticleSystem explosion;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        MoveForward();

    }

    public virtual void SetStats() 
{
        hp = 10;
        speed = 10;

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { 
            hp -= 1;
            Destroy(collision.gameObject);
        }

       else if (collision.gameObject.CompareTag("Missile"))
        {
            hp -= 5;
            Destroy(collision.gameObject);
            
        }

       else if (collision.gameObject.CompareTag("End"))
        {
            gameManager.GameOver();

        }
        else
        {
            hp -= 100;
        }

        if (hp <= 0)
        {
            rend.enabled = false;
            rend1.enabled = false;
            rend2.enabled = false;
            collide.enabled = false;
            explosion.Play();
        }

    }
     private void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

}
