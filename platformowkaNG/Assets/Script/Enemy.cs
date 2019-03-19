using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Health playerHealth;
    public int health = 100;
    public GameObject deathEffect;
    public CameraFollow cf;
    // Start is called before the first frame update
    public void TakeDamege(int damage)
    {
        health -= damage;

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
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.health = playerHealth.health - 1;        
            Debug.Log("Enemy hit");

        }
    }


    void EnemyShoot()
    {

    }
}
