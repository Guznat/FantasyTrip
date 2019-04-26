using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGhost : MonoBehaviour
{

    public Rigidbody2D rb;
    public int health = 1500;
    public GameObject deathEffect;
    public CameraFollow cf;
    public Transform playerPosition;
    public Animator anim;
    bool facingRight = false;
    float dirX;
    Vector3 localScale;
    public Slider healthBar;
    public GameObject bossUI;
    public Transform firePoint;
    public GameObject spell;

    public float shotingDistance;
    private float timeBtwShots;
    public float cooldown;


    void Start()
    {
        localScale = transform.localScale;
        dirX = -1f;
    }

    void Update()
    {

        healthBar.value = health;
        anim.SetBool("isAttack", false);

        if (transform.position.x < playerPosition.position.x)
        {
            dirX = 1f;
        }
        else if (transform.position.x > playerPosition.position.x)
        {
            dirX = -1f;
        }


        if (Vector2.Distance(transform.position, playerPosition.position) < shotingDistance)
        {
            if (timeBtwShots <= 0)
            {
                Shot();
                timeBtwShots = cooldown;
                anim.SetBool("isAttack", true);
                anim.SetBool("isRuning", false);
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }


        }

    }

    private void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;

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
        bossUI.SetActive(false);
        cf.ShakeCamera();
        FindObjectOfType<AudioManager>().Play("smierc_czaszka");
    }

    public void Shot()
    {
        Instantiate(spell, firePoint.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("enemy_shot");
    }
}
