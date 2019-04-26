using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArenaTrigger : MonoBehaviour
{
    public Animator arenaFilar;
    public GameObject bossUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bossUI.SetActive(true);
            arenaFilar.SetBool("IsClose", true);
            FindObjectOfType<AudioManager>().Play("boss_arena");
            Object.Destroy(gameObject);
        }
        
    }
}
