using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTrigger : MonoBehaviour
{
    public GameObject defaultBackground;
    public GameObject activeBackground;
    public GameObject backgroundForChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            defaultBackground.SetActive(false);
            activeBackground.SetActive(false);
            backgroundForChange.SetActive(false);
            backgroundForChange.SetActive(true);
        }

    }


}
