using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Button playBtn;
    public Button settingsBtn;
    public Button quitBtn;
    public Button extrasBtn;
    public Button backMenuBtn;
    public Animator transitionAnimation;

    public Health playerHealth;

    private int levelToLoad;
    void Start()
    {
        playBtn = playBtn.GetComponent<Button>();
        settingsBtn = settingsBtn.GetComponent<Button>();
        quitBtn = quitBtn.GetComponent<Button>();
        extrasBtn = extrasBtn.GetComponent<Button>();
        backMenuBtn = backMenuBtn.GetComponent<Button>();
    }
    private void Update()
    {
        if(playerHealth.health <= 0)
        {
            StartTransitionScene(4);
        }
    }
    public void PlayGame()
    {

        StartTransitionScene(1);
    }

    public void PlaySettings()
    {

        StartTransitionScene(2);
    }

    public void PlayExtras()
    {
       
        StartTransitionScene(3);
    }

    public void BackMenu()
    {
        Time.timeScale = 1f;
        StartTransitionScene(0); ;
    }

    public void Exit()
    {
        Application.Quit();
    }


    public void StartTransitionScene(int levelIndex)
    {
        levelToLoad = levelIndex;
        transitionAnimation.SetTrigger("end");
        
    }
    public void EndTransitionScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
