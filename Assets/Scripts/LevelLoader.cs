using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public bool isClicked;
    public string LevelName;
    void Start()
    {

    }
    public void OnClick()
    {
        isClicked = true;
    }
    void Update()
    {
        if (isClicked)
        {
            SceneManager.LoadScene(LevelName);
            Time.timeScale = 1;
        }
    }
}
