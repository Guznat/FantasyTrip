using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingGround : MonoBehaviour
{
    public Health playerHealth;
    public PlayerMovment pm;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.Hit();
            StartCoroutine(pm.Knockback(0.1f, 10, pm.transform.position));


            Debug.Log("Enemy hit");

        }
    }
}
