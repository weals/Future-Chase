using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

// Author: Xisheng Zhang
public class GameStartCountdown : MonoBehaviour
{
    public GameObject countdownPanel;
    public TMP_Text countdownText;
    private float countdownDuration = 3f;
    private PlayerController playerController;

    public AICarController aiCarController;
    public AudioSource countdownSound;

    void Awake()
    {
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
                {
                    playerController = playerObject.GetComponent<PlayerController>();
                }
    }
    void Start()
    {
        if (playerController != null)
        {
            playerController.SetPlayerControlEnabled(false);
        }
        if (aiCarController != null)
        {
            aiCarController.SetAIControlEnabled(false);
        }
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {
        countdownPanel.SetActive(true);

        float endTime = Time.time + countdownDuration;
        AudioSource[] sources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        for (int index = 0; index < sources.Length; ++index)
        {
            if (sources[index].clip != countdownSound.clip)
                sources[index].mute = true;
        }
        while (Time.time < endTime)
        {
            float timeLeft = endTime - Time.time;
            countdownText.text = Mathf.Ceil(timeLeft).ToString();

            if (countdownSound != null)
            {
                countdownSound.PlayOneShot(countdownSound.clip);
            }

            yield return new WaitForSeconds(1f);
        }

        for (int index = 0; index < sources.Length; ++index)
        {
            sources[index].mute = false;
        }
        countdownSound.Stop();

        countdownPanel.SetActive(false);

        if (playerController != null)
        {
            playerController.SetPlayerControlEnabled(true);
        }
        if (aiCarController != null)
        {
            aiCarController.SetAIControlEnabled(true);
        }
    }
}
