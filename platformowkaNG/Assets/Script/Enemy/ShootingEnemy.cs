using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    private Transform player;
    public Transform firePoint;
    public GameObject spell;
    public float shotingDistance;
    public GameObject deathEffect;
    public CameraFollow cf;
    public int health = 100; 

    private float timeBtwShots;
    public float cooldown;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        

        if (Vector2.Distance(transform.position, player.position) < shotingDistance)
        {
            if (timeBtwShots <= 0)
            {
                Shot();
                timeBtwShots = cooldown;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
            

        }
    }

    public void Shot()
    {
        Instantiate(spell, firePoint.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("enemy_shot");
    }

    public void TakeDamege(int damage)
    {
        health -= damage;
        cf.ShakeCamera();
        if (health <= 0)
        {
            Die();

        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        cf.ShakeCamera();
        FindObjectOfType<AudioManager>().Play("smierc_czaszka");
    }

}
