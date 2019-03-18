using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{

    public Animator animator;

    public int health;
    public int max_health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    private void Update()
    {
        if (health > max_health)
        {
            health = max_health;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            if (i < max_health)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            animator.SetBool("IsHit", true);
        }
        else if (collision.gameObject.CompareTag("Spike"))
        {
            animator.SetBool("IsHit", true);
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.SetBool("IsHit", false);
    }
}
