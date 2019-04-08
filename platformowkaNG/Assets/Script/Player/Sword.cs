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
        ShootingEnemy shootingEnemy = hitInfo.GetComponent<ShootingEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamege(damage);
            

        }
        else if(shootingEnemy != null)
        {
            shootingEnemy.TakeDamege(damage);
            
        }
        
    }
}
