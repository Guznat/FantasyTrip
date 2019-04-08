using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioTriggerOnButton : MonoBehaviour
{
    [SerializeField]
    private Dialog dialog;
    public GameObject dialogObject;
    public Button dialogBtn;
    public bool DestroyOnExit;
    private bool buttonPress = false;


    void Update()
    {
        if (buttonPress == true)  
        {
            // Ten kawałek kodu był podpiety pod dialogbutton, ale odpalał dialogi z lagiem nawet 5-6sek, 
            // przeniesienie go do funkcji update rozwiazało sprawe.

            FindObjectOfType<DialogManager>().StartDialog(dialog);
            if (DestroyOnExit == true)
            {
                Object.Destroy(gameObject);
            }
            buttonPress = false;
        }



        dialogBtn.onClick.AddListener(StartDialog);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dialogObject.SetActive(true);
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dialogObject.SetActive(false);
        }
    }


    public void StartDialog()
    {
        buttonPress = true;
    }
}