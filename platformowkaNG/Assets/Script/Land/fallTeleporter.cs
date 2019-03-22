using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallTeleporter : MonoBehaviour
{
    public GameObject player;
    public Transform startArea;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = startArea.position;
    }
}

