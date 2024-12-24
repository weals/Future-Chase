using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstructionText : MonoBehaviour
{
    private TextMeshProUGUI instructionText;
    private string[] instructions;

    private int currentInstructionIndex = 0;
    private float timer = 0.0f;
    private float instructionTime = 4.0f;

    void Start()
    {
        instructionText = GetComponent<TextMeshProUGUI>();
        Debug.Log(instructionText);
        instructions = new string[]
        {
            "Welcome to the game!",
            "Use the arrow or WASD keys to move",

            "Collect speed boosts to temporarily increase your speed",
            "Collect coins to buy upgrades for the next level",

            "If you die, don't worry! You will be respawned",

            "To aim your gun, move your cursor",
            "To shoot, press the left mouse button",
            "You can shoot your opponent to slow them down",
            "You can't shoot during the start of the game",
            "You can also shoot the barrel obstacles to destroy them",

            "On the bottom left corner, you can see a minimap",
            "Right above it, you can see a progress bar indicating your progress along the track",
            "On the bottom right corner, you can see your current speed",
            "On the top right corner, you can see the number of coins you have collected",

            "You can pause/unpause the game by clicking the \"ESC\" key",

            "Your goal is to reach the finish line before your opponent does",
            "When you feel ready, start the game by clicking the \"Start!\" button!",
            "The game will also start once you reach the finish line in the training mode",
            "Good luck!"
        };
        instructionText.text = instructions[currentInstructionIndex];

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= instructionTime && currentInstructionIndex < instructions.Length - 1)
        {
            currentInstructionIndex++;
            timer = 0.0f;

            instructionText.text = instructions[currentInstructionIndex];
        }



    }
}
