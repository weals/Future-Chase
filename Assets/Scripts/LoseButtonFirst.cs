using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseButtonFirst : MonoBehaviour
{
    public void StartFirst()
    {
        SceneManager.LoadScene("First_Scene");
        Time.timeScale = 1f;
    }
}
