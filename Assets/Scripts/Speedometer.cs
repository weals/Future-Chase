using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Speedometer : MonoBehaviour
{
    private GameObject target;

    private float maxSpeed = 260f;

    private float minSpeedArrowAngle = 3.0f;
    private float maxSpeedArrowAngle = -182.0f;
    private float speedMultiplier = 4.5f;

    [Header("UI")]
    public TextMeshProUGUI speedLabel;
    public RectTransform arrow;

    private float speed = 0.0f;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        speed = target.GetComponent<PlayerController>().currentSpeed * speedMultiplier;

        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " MPH";
        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}
