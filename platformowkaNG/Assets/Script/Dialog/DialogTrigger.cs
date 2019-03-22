using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Object.Destroy(gameObject);
    }

}
