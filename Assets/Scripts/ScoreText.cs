using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreText : MonoBehaviour
{
    private int score = 0;
    private Text textBox;
    void Start()
    {
        GlobalEventManager.SaveResutl.AddListener(SaveResult);
        GlobalEventManager.PointGetting.AddListener(GetPoint);
        textBox = GetComponent<Text>();
        textBox.text = score.ToString();
    }
    private void GetPoint(int num)
    {
        score += num;
        textBox.text = "" + score;
    }
    private void SaveResult()
    {
        if (score > PlayerPrefs.GetInt("BestScore", 0))
            PlayerPrefs.SetInt("BestScore", score);
    }
}
