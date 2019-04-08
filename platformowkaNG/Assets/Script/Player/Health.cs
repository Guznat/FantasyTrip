using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{

    public Animator animator;

    public int health;
    public int max_health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public CameraFollow cf;
    public SceneTransitions st;
    public GameObject UI;
    public PlayerMovment pm;



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

        if(health <= 0)
        {
            Die();          
        }



    }

    public void Hit()
    {
        health -= 1;
        cf.ShakeCamera();
        animator.SetBool("IsHit", true);
        FindObjectOfType<AudioManager>().Play("player_hit");
    }
    public void HitEnd()
    {
        animator.SetBool("IsHit", false);
    }

    void Die()
    {
        animator.SetBool("IsHit", false);
        animator.SetBool("IsAttack", false);
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsShooting", false);
        animator.SetBool("IsCrouching", false);
        animator.SetBool("IsDead", true);
        UI.SetActive(false);
        pm.ZeroVelocity();
    }

    void GameOver()
    {
        st.StartTransitionScene(4);
    }

    void PlaySadSong()
    {
        FindObjectOfType<AudioManager>().Play("sad_piano");
    }

 
}
