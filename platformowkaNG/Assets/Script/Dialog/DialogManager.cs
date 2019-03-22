using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{   
    public Text dialogText;
    public GameObject background;
    public Animator animator;
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialog(Dialog dialog)
    {

        background.SetActive(true);
        animator.SetBool("IsOpen", true);
       
        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

        
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(LivingText(sentence));

    }
    IEnumerator LivingText (string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null; //zwraca po kazdej klatce
        }
    }

    void EndDialog()
    {
        Debug.Log("Koniec rozmowy");
        animator.SetBool("IsOpen", false);
        background.SetActive(false);


    }


}
