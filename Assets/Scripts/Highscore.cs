using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    private int highScore;

    [SerializeField]
    private Text highScoreText;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Update()
    {
        if (GameManager.Instance.coin > highScore)
        {
            PlayerPrefs.SetInt("HighScore", GameManager.Instance.coin);
        }

        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore").ToString();
    }
}
