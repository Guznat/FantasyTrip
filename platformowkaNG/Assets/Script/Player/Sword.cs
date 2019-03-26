using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage = 50;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamege(damage);
            FindObjectOfType<AudioManager>().Play("sword");

        }
        else
        {

            FindObjectOfType<AudioManager>().Play("sword");
        }
    }
}
