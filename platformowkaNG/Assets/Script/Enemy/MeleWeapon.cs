using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleWeapon : MonoBehaviour
{
   public Health playerHealth;
    public PlayerMovment pm;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.Hit();
            // StartCoroutine(pm.Knockback(5f, 50, pm.transform.position));
        }
    }
}
