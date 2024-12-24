using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    CanvasGroup settingsMenuCanvasGroup;
    void Start()
    {
        settingsMenuCanvasGroup = GameObject.Find("SettingsGroup").GetComponent<CanvasGroup>();
        settingsMenuCanvasGroup.interactable = false;
        settingsMenuCanvasGroup.blocksRaycasts = false;
        settingsMenuCanvasGroup.alpha = 0f;
    }

    public void onClick()
    {
        if (settingsMenuCanvasGroup.interactable)
        {
            settingsMenuCanvasGroup.interactable = false;
            settingsMenuCanvasGroup.blocksRaycasts = false;
            settingsMenuCanvasGroup.alpha = 0f;
            return;
        }
        settingsMenuCanvasGroup.alpha = 1f;
        settingsMenuCanvasGroup.interactable = true;
        settingsMenuCanvasGroup.blocksRaycasts = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (settingsMenuCanvasGroup.interactable)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                settingsMenuCanvasGroup.interactable = false;
                settingsMenuCanvasGroup.blocksRaycasts = false;
                settingsMenuCanvasGroup.alpha = 0f;
            }
        }
    }
}
