using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;
    void Start()
    {
        scoreText = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
        UpdateScore();

    }

    public void UpdateScore()
    {
        score = PlayerPrefs.GetInt("coins");
        scoreText.text = "Coins: " + score;
    }

    public void onClickDamageUp()
    {
        if (PlayerPrefs.GetInt("coins") < 10)
        {
            return;
        }
        float currDamage = PlayerPrefs.GetFloat("damage");
        PlayerPrefs.SetFloat("damage", currDamage + 0.5f);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 10);
        UpdateScore();
        Debug.Log("Damage: " + PlayerPrefs.GetFloat("damage"));
    }

    public void onClickPowerUpBoost()
    {
        if (PlayerPrefs.GetInt("coins") < 15)
        {
            return;
        }
        float currPowerUpBoost = PlayerPrefs.GetFloat("powerUp");
        PlayerPrefs.SetFloat("powerUp", currPowerUpBoost + 1f);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 15);
        UpdateScore();
    }

    public void onClickSpeedUp()
    {
        if (PlayerPrefs.GetInt("coins") < 10)
        {
            return;
        }
        float currSpeed = PlayerPrefs.GetFloat("speed");
        PlayerPrefs.SetFloat("speed", currSpeed + 1.5f);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 10);
        UpdateScore();
    }

    public void onClickAINerf()
    {
        if (PlayerPrefs.GetInt("coins") < 15)
        {
            return;
        }
        float currAINerf = PlayerPrefs.GetFloat("aiSpeed");
        PlayerPrefs.SetFloat("aiSpeed", currAINerf - 1.5f);
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - 15);
        UpdateScore();
    }
}
