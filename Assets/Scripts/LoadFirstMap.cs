using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstMap : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    public void StartFirstMap()
    {
        SceneManager.LoadScene("First_Scene");
        Time.timeScale = 1f;
    }
}
