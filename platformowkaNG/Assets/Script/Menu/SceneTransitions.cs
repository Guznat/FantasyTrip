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
    public Animator transitionAnimation;
    void Start()
    {
        playBtn = playBtn.GetComponent<Button>();
        settingsBtn = settingsBtn.GetComponent<Button>();
        quitBtn = quitBtn.GetComponent<Button>();
        extrasBtn = extrasBtn.GetComponent<Button>();
    }

    public void PlayGame()
    {
        StartCoroutine(LoadScene());
        SceneManager.LoadScene(1);
    }

    public void PlaySettings()
    {
        StartCoroutine(LoadScene());
        SceneManager.LoadScene(2);
    }

    public void PlayExtras()
    {
        StartCoroutine(LoadScene());
        SceneManager.LoadScene(3);
    }

    public void Exit()
    {
        Application.Quit();
    }


    IEnumerator LoadScene()
    {
        transitionAnimation.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
    }
}
