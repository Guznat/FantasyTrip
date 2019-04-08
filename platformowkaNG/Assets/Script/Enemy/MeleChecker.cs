using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleChecker : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Enemy.isAttacking = true;
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Enemy.isAttacking = false;
        }
    }
}
