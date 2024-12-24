using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinButtonFirst : MonoBehaviour
{
    public void StartSecondMap()
    {
        int newCoins = GameObject.FindWithTag("Player").GetComponent<PlayerController>().count;
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + newCoins);
        SceneManager.LoadScene("Upgrade Scene");
        PlayerPrefs.SetInt("level", 2);
        Time.timeScale = 1f;
    }
}
