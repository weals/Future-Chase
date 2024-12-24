using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartFirst : MonoBehaviour
{
    public void StartGame()
    {

        SceneManager.LoadScene("First_Scene");
        Time.timeScale = 1f;

    }
}
