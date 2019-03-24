using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField]
    private Dialog dialog;
    public bool DestroyAfterDialog;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<DialogManager>().StartDialog(dialog);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (DestroyAfterDialog == true)
            {
                Object.Destroy(gameObject);
            }
        }
        
    }

}
