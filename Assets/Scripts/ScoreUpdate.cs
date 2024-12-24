using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreUpdate : MonoBehaviour
{
    // Start is called before the first frame update

    public static int score = 0;
    public TextMeshProUGUI scoreText;
    void Start()
    {
        score = 0;
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();

        UpdateScore();
        
    }

    public void AddScore(int newScoreValue) {
        score = newScoreValue;
        UpdateScore();
    }

    public void UpdateScore() {
        scoreText.text = "Coins: " + score;
    }
}
