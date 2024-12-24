using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Author: Xisheng Zhang
public class GameTraining : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    public void StartGameTraining()
    {
        SceneManager.LoadScene("Training New");
        Time.timeScale = 1f;
    }
}
