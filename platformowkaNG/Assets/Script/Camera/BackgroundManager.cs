using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
   public Background1[] background;

    void Awake()
    {
        foreach (Background1 bg in background)
        {

            bg.background.GetComponent<GameObject>();
            
        }
    }


    public void Change(string name)
    {
        Background1 bg = Array.Find(background, bg1 => bg1.name == name);
        foreach (Background1 bgforchange in background)
        {
            bg.background.SetActive(true);
            if (bgforchange.name != name)
            {
                bgforchange.background.SetActive(false);
            }
           
        }
       
    }
}
