using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float detectDistace = 10f;
    public Rigidbody2D rb;
    public Health playerHealth;
    public Transform weaponTrigger;
    public int health = 100;
    public GameObject deathEffect;
    public CameraFollow cf;
    public Transform playerPosition;
    public float moveSpeed = 0.3f;
    public Animator anim;
    bool facingRight = false;
    float dirX;
    Vector3 localScale;
    

    public static bool isAttacking = false;

    void Start()
    {
        localScale = transform.localScale;
        dirX = -1f;
    }

    void Update()
    {
       

       
        if(transform.position.x < playerPosition.position.x)
        {
            dirX = 1f;
        }
        else if (transform.position.x > playerPosition.position.x)
        {
            dirX = -1f;
        }

        if (isAttacking)
            anim.SetBool("isAttacking", true);
        else if(!isAttacking)
            anim.SetBool("isAttacking", false);
 
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            anim.SetBool("isWalking", false);
            if (Vector2.Distance(transform.position, playerPosition.position) < detectDistace)
            {
                rb.velocity = new Vector2(dirX * (moveSpeed * Time.deltaTime), rb.velocity.x);
                anim.SetBool("isWalking", true);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isWalking", false);
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
            cf.ShakeCamera();
            FindObjectOfType<AudioManager>().Play("smierc_czaszka");
        }

    public void StopAtack()
    {
        if (Vector2.Distance(transform.position, playerPosition.position) > detectDistace)
            isAttacking = false;
    }
}
