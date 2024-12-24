using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void NextLevel()
    {
        if (PlayerPrefs.GetInt("level") == 2)
        {
            SceneManager.LoadScene("Second_Scene");
            Time.timeScale = 1f;
        }
        else if (PlayerPrefs.GetInt("level") == 3)
        {
            SceneManager.LoadScene("Third_Scene");
            Time.timeScale = 1f;
        }
    }
}
