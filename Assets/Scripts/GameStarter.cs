using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameStarter : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    public void StartGame() {

        SceneManager.LoadScene("Garage");
        Time.timeScale = 1f;

    }
}
