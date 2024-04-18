using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject unpauseButton;
    [SerializeField] private GameObject pauseButton;
    private void Start()
    {
        pauseButton.SetActive(true);
        unpauseButton.SetActive(false);
    }
    public void SetPause()
    {
        GlobalEventManager.SetPause();
        Time.timeScale = 0f;
        GlobalData.Pause();
        pauseButton.SetActive(false);
        unpauseButton.SetActive(true);
    }
    public void SetUnpause()
    {
        GlobalEventManager.SetUnpause();
        Time.timeScale = 1f;
        GlobalData.Unpause();
        pauseButton.SetActive(true);
        unpauseButton.SetActive(false);
    }
}
