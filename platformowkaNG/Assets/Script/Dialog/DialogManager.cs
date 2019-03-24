using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class DialogManager : MonoBehaviour
{   
    public Text dialogText;
    public GameObject background;
    public Animator animator;
    private Queue<string> sentences;
    private Queue<string> audioSentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        audioSentences = new Queue<string>();
    }


    public void StartDialog(Dialog dialog)
    {

        background.SetActive(true);
        animator.SetBool("IsOpen", true);
       
        sentences.Clear();
        audioSentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        foreach (string audioSentence in dialog.audioSentences)
        {

            audioSentences.Enqueue(audioSentence);
        }
        DisplayNextSentence();

        
    }
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 && audioSentences.Count == 0)
        {
            EndDialog();
            return;
        }
        string sentence = sentences.Dequeue();
        string audioSentence = audioSentences.Dequeue();
        StopDialog(audioSentence);
        StopAllCoroutines();
        StartCoroutine(LivingText(sentence));
        StopDialog(audioSentence);
        PlayDialog(audioSentence);

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

    void PlayDialog(string audioSentence)
    {
        FindObjectOfType<AudioManager>().Play(audioSentence);
    }
    void StopDialog(string audioSentence)
    {
        FindObjectOfType<AudioManager>().Stop(audioSentence);
    }



    void EndDialog()
    {
        Debug.Log("Koniec rozmowy");
        animator.SetBool("IsOpen", false);
        background.SetActive(false);
    }


}
