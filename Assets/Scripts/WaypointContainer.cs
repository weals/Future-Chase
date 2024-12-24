using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointContainer : MonoBehaviour
{
    public List<Transform> waypoints;
    private List<CheckpointSingle> waypointSingleList;
    private int nextCheckpointIndex;
    public GameObject wrongWayUI;
    void Awake()
    {
        waypointSingleList = new List<CheckpointSingle>();
        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {
            waypoints.Add(child);

            CheckpointSingle checkpoint = child.GetComponent<CheckpointSingle>();

            if (checkpoint == null) continue;
            checkpoint.setTrack(this);
            waypointSingleList.Add(checkpoint);
        }
        waypoints.Remove(waypoints[0]);
        nextCheckpointIndex = 0;
    }

    public void PlayerThroughCheckpoint(CheckpointSingle checkpoint, GameObject player)
    {
        int index = waypointSingleList.IndexOf(checkpoint);
        RaceManager.UpdateCheckpoint(player, checkpoint.transform, index);
        if (index == nextCheckpointIndex && player.CompareTag("Player"))
        {
            //correct checkpoint
            nextCheckpointIndex = (nextCheckpointIndex + 1) % waypointSingleList.Count;
            wrongWayUI.SetActive(false);
        }
        else if (player.CompareTag("Player"))
        {
            //wrong checkpoint, display in UI
            if (index < nextCheckpointIndex - 1)
            {
                Debug.Log("Wrong checkpoint");
                wrongWayUI.SetActive(true);
            }
        }

    }
}