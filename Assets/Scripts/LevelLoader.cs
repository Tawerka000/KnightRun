using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private string LevelName;
    public void OnClick()
    {
        SceneManager.LoadScene(LevelName);
        GlobalData.Unpause();
    }
}
