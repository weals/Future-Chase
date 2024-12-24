using UnityEngine;

public static class RaceManager
{
    public static int PlayerCheckpointIndex { get; set; }
    public static Transform PlayerCheckpointTransform { get; set; }
    public static int AICheckpointIndex { get; set; }
    public static Transform AICheckpointTransform { get; set; }

    public static void UpdateCheckpoint(GameObject player, Transform checkpointTransform, int checkpointIndex)
    {
        if (player.CompareTag("Player"))
        {
            PlayerCheckpointIndex = checkpointIndex;
            PlayerCheckpointTransform = checkpointTransform;
            Debug.Log("Checkpoint index: " + PlayerCheckpointIndex);
        }
        else if (player.CompareTag("AI"))
        {
            AICheckpointIndex = checkpointIndex;
            AICheckpointTransform = checkpointTransform;
        }
    }
}
