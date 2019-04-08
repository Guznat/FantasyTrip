using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomingShot : MonoBehaviour
{
    public float speed = 1f;
    public GameObject spellImpact;
    private Transform playerPosition;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(playerPosition.position.x, playerPosition.position.y);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if(transform.position.x ==target.x && transform.position.y == target.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        Health player = hitInfo.GetComponent<Health>();
        if (player != null)
        {
            
            Instantiate(spellImpact, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("enemy_shot");
            player.Hit();
            Destroy(gameObject);

        }
        else
        {
            FindObjectOfType<AudioManager>().Play("enemy_shot");
            Instantiate(spellImpact, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
