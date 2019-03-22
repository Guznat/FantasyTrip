using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public string audioNameToStart;
    public string audioNameToStop;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<AudioManager>().Stop(audioNameToStop);
        FindObjectOfType<AudioManager>().Play(audioNameToStart);
    }
}
