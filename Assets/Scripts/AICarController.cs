using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICarController : MonoBehaviour
{
    public WaypointContainer waypointContainer;
    public List<Transform> waypoints;
    public int currentWaypoint;
    private PlayerController carController;
    public float waypointRange;
    private float steerStrength = 50f;
    private float accelerationStrength = 1f;
    private bool isAIControlEnabled = true;

    private float decelerationRate = 3.5f;

    private bool isInBrakingZone = false;
    private float brakingSpeed = 20f;
    private GameObject player;
    public float rubberBandThreshold = 75f;
    private float rubberBandFactor = 0.5f;
    public float minSpeed = 25f;


    void Start()
    {
        carController = GetComponent<PlayerController>();
        waypoints = waypointContainer.waypoints;
        currentWaypoint = 0;
        waypointRange = 5;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetAIControlEnabled(bool isEnabled)
    {
        isAIControlEnabled = isEnabled;
    }

    void Update()
    {
        if (!isAIControlEnabled) return;

        if (isInBrakingZone)
        {
            carController.currentSpeed = Mathf.Lerp(carController.currentSpeed, brakingSpeed, Time.deltaTime * decelerationRate);
        }

        if (Vector3.Distance(waypoints[currentWaypoint].position, transform.position) < waypointRange)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Count)
            {
                currentWaypoint = 0;
            }
        }

        Vector3 relativeVector = transform.InverseTransformPoint(waypoints[currentWaypoint].position);
        float steerDirection = (relativeVector.x / relativeVector.magnitude) * steerStrength;
        carController.movementX = Mathf.Clamp(steerDirection, -1, 1);


        if (relativeVector.magnitude > waypointRange)
        {
            carController.movementY = accelerationStrength;
        }
        else
        {
            carController.movementY = 0;
        }

        bool isAIAhead = RaceManager.AICheckpointIndex > RaceManager.PlayerCheckpointIndex;

        //rubber banding

        // float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        // if (distanceToPlayer > rubberBandThreshold && isAIAhead)
        // {
        //     float excessDistance = distanceToPlayer - rubberBandThreshold;
        //     float speedReduction = excessDistance * rubberBandFactor;
        //     carController.currentSpeed = Mathf.Max(minSpeed, carController.currentSpeed - speedReduction);
        // }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BrakingZone"))
        {
            isInBrakingZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BrakingZone"))
        {
            isInBrakingZone = false;
        }
    }
}
