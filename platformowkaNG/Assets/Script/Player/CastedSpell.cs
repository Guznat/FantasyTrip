using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastedSpell : MonoBehaviour
{
    public float speed = 50f;
    public Rigidbody2D rgbd;
    public int damage = 30;
    public GameObject spellEnemyImpact;
    public GameObject spellGroundInpact;
    // Start is called before the first frame update
    void Start()
    {
        rgbd.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        ShootingEnemy shootingEnemy = hitInfo.GetComponent<ShootingEnemy>();
        if (enemy != null)
        {
            FindObjectOfType<AudioManager>().Play("fireball_impact_ground");
            enemy.TakeDamege(damage);
            Instantiate(spellEnemyImpact, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (shootingEnemy != null)
        {
            FindObjectOfType<AudioManager>().Play("fireball_impact_ground");
            shootingEnemy.TakeDamege(damage);
            Instantiate(spellEnemyImpact, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            FindObjectOfType<AudioManager>().Play("fireball_impact_ground");
            Instantiate(spellGroundInpact, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
