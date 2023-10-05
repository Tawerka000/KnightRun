using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreMenu : MonoBehaviour
{
    private int score;
    public Text scoreT;
    void Start()
    {
        score = PlayerPrefs.GetInt("BestScore", 0);
        scoreT.text = score.ToString();
    }
}
