using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishLine : MonoBehaviour
{

    public bool finishedRace = false;
    public GameObject resultPanel;
    public GameObject WinButton;
    public TextMeshProUGUI resultText;

    private PauseMenuToggle pauseMenuToggle;
    [SerializeField] private AudioSource finishLineSound;

    private void Start()
    {
        pauseMenuToggle = FindObjectOfType<PauseMenuToggle>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("AI"))
        {
            resultText.text = "You Lose!";
            resultPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else if (other.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("level") == 3) {
                SceneManager.LoadScene("GameWin");
                return;
            }
            AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
            for (int index = 0; index < sources.Length; ++index)
            {
                sources[index].mute = true;
            }

            finishLineSound.mute = false;
            resultText.text = "You Win!";
            finishLineSound.volume = 5.0f;
            finishLineSound.Play();
            resultPanel.SetActive(true);
            WinButton.SetActive(true);
            Time.timeScale = 0;

        }
        if (pauseMenuToggle != null)
        {
            finishedRace = true;
            pauseMenuToggle.getToggle();
        }
    }
}
