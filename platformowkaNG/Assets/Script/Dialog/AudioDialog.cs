using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDialog : MonoBehaviour
{
    public Button next;
    public string stage1;
    public string stage2;
    public string stage3;

    private int audio;
    public int audioAmount;
    private void Start()
    {
        audio = audioAmount;
    }
    void Update()
    {
        next.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        if(audio == 3)
        {
            FindObjectOfType<AudioManager>().Play(stage1);
        }
        if (audio == 2)
        {
            FindObjectOfType<AudioManager>().Play(stage2);
        }
        if (audio == 1)
        {
            FindObjectOfType<AudioManager>().Play(stage3);
        }
        audio--;
    }
}
