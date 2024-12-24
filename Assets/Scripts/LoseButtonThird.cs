using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseButtonThird : MonoBehaviour
{
    public void StartThird()
    {
        SceneManager.LoadScene("Third_Scene");
        Time.timeScale = 1f;
    }
}
