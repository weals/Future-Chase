using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReStarThird : MonoBehaviour
{
    public void StartGame()
    {

        SceneManager.LoadScene("Third_Scene");
        Time.timeScale = 1f;

    }
}
