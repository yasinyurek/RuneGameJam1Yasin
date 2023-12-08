using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{


    public GameObject HistoryPanel;
    public GameObject HowToPlayPanel;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToMenuHistory()
    {
        HistoryPanel.SetActive(false);
    }

    public void BackToMenuHowToPlay()
    {
        HowToPlayPanel.SetActive(false);
    }

    public void OpenHistory()
    {
        HistoryPanel.SetActive(true);
    }

    public void OpenHowToPlay()
    {
        HowToPlayPanel.SetActive(true);
    }



}
