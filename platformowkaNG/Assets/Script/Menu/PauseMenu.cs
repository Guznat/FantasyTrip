using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pause = false;
    public Button pauseBtn;
    public Button resumeBtn;

    public GameObject pauseUIPanel;

    // Update is called once per frame
    void Update()
    {
        pauseBtn.onClick.AddListener(Pause);
    }


    public void Pause()
    {
        pauseUIPanel.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void Resume()
    {
        pauseUIPanel.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }

}
