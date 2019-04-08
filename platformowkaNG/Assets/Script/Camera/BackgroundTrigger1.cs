using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrigger1 : MonoBehaviour
{
    public string backgroundName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovment player = collision.GetComponent<PlayerMovment>();
        if (player != null)
        {
            FindObjectOfType<BackgroundManager>().Change(backgroundName);
        }
    }


}
