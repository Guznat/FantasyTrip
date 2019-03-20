using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittingGround : MonoBehaviour
{
    public Health playerHealth;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.health = playerHealth.health - 1;
            Debug.Log("Enemy hit");

        }
    }
}
