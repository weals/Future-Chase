using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Author: Xisheng Zhang
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    private float speedBoost;
    public float duration = 2f;

    private bool isPowerUpActive = false;
    private PlayerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerController = other.GetComponent<PlayerController>();

            if (playerController != null && !isPowerUpActive)
            {
                ApplySpeedBoost();

                Invoke("RevertSpeedBoost", duration);
                isPowerUpActive = true;
                gameObject.SetActive(false);
            }
        }
    }

    private void ApplySpeedBoost()
    {
        speedBoost = PlayerPrefs.GetFloat("powerUp");
        playerController.maxSpeed += speedBoost;

        playerController.currentSpeed += speedBoost;
    }

    private void RevertSpeedBoost()
    {
        speedBoost = PlayerPrefs.GetFloat("powerUp");
        if (playerController != null)
        {
            playerController.currentSpeed -= speedBoost;
            playerController.maxSpeed -= speedBoost;
        }
        isPowerUpActive = false;
    }
}
