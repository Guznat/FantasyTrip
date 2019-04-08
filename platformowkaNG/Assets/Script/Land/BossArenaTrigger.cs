using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArenaTrigger : MonoBehaviour
{
    public Animator arenaFilar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            arenaFilar.SetBool("IsClose", true);
            FindObjectOfType<AudioManager>().Play("boss_arena");
            Object.Destroy(gameObject);
        }
        
    }
}
