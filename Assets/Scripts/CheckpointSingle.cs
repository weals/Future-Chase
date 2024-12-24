using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSingle : MonoBehaviour
{
    // Start is called before the first frame update
    private WaypointContainer waypointContainer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("AI"))
        {
            waypointContainer.PlayerThroughCheckpoint(this, other.gameObject);
        }
    }

    public void setTrack(WaypointContainer wayPointContainer)
    {
        this.waypointContainer = wayPointContainer;
    }
}
