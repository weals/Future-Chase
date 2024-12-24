using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseButtonSecond : MonoBehaviour
{
    public void StartFirst()
    {
        SceneManager.LoadScene("Second_Scene");
        Time.timeScale = 1f;
    }
}
