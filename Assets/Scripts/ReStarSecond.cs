using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReStarSecond : MonoBehaviour
{
    public void StartGame()
    {

        SceneManager.LoadScene("Second_Scene");
        Time.timeScale = 1f;

    }
}
