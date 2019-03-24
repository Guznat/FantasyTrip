using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialog
{
    [TextArea(1,10)]
    public string[] sentences;

    [TextArea(1, 10)]
    public string[] audioSentences;
}
